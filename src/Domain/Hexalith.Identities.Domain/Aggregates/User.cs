namespace Hexalith.Identities.Domain.Aggregates;

using System;
using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Messages;
using Hexalith.Domain.Notifications;
using Hexalith.Domain.Users.Models;
using Hexalith.Identities.Domain.Helpers;
using Hexalith.Identities.Domain.ValueObjects;
using Hexalith.Identities.Events.Users;

/// <summary>
/// The user aggregate.
/// </summary>
[DataContract]
public sealed record User(
    /// <summary>
    /// The user identifier.
    /// </summary>
    [property: DataMember(Order = 1)] string Id,
    /// <summary>
    /// The user name.
    /// </summary>
    [property: DataMember(Order = 2)] string Name,
    /// <summary>
    /// The user email.
    /// </summary>
    [property: DataMember(Order = 3)] UserEmail EmailInformation,
    /// <summary>
    /// The user globalization and localization settings.
    /// </summary>
    [property: DataMember(Order = 4)] UserGlobalization Globalization,
    /// <summary>
    /// The user login.
    /// </summary>
    [property: DataMember(Order = 5)] UserLogin? Login,
    /// <summary>
    /// The partitions the user belongs to.
    /// </summary>
    [property: DataMember(Order = 6)] IEnumerable<string> Partitions,
    /// <summary>
    /// The user external identities (Microsoft, Google, etc.).
    /// </summary>
    [property: DataMember(Order = 7)] IEnumerable<ExternalIdentity> ExternalIdentities,
    /// <summary>
    /// The user enabled status.
    /// </summary>
    [property: DataMember(Order = 9)] UserStatus Status,
    /// <summary>
    /// This user is a global administrator.
    /// </summary>
    [property: DataMember(Order = 10)] bool IsGlobalAdministrator)
    : Aggregate, IUser
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    public User()
        : this(
             string.Empty,
             string.Empty,
             new UserEmail(string.Empty, false),
             new UserGlobalization(),
             null,
             [],
             [],
             UserStatus.PendingEmailConfirmation,
             false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="registered">User registered event.</param>
    public User(UserRegistered registered)
        : this(
             (registered ?? throw new ArgumentNullException(nameof(registered))).Id,
             registered.Name,
             new UserEmail(registered.Email, false),
             new UserGlobalization(),
             null,
             [],
             [],
             UserStatus.PendingEmailConfirmation,
             false)
    {
    }

    /// <inheritdoc/>
    string IUser.Email => EmailInformation.Email;

    /// <inheritdoc/>
    public override (IAggregate Aggregate, IEnumerable<BaseMessage> Messages) Apply(BaseEvent domainEvent)
    {
        CheckValid(domainEvent);
        return domainEvent switch
        {
            UserRegistered e => Do(e),
            UserEmailValidated e => Do(e),
            UserEnabled e => Do(e),
            UserDisabled e => Do(e),
            _ => base.Apply(domainEvent),
        };
    }

    /// <inheritdoc/>
    public override bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => IdentitiesDomainHelper.GetUserAggregateId(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => IdentitiesDomainHelper.UserAggregateName;

    private (User Aggregate, IEnumerable<BaseMessage> Messages) Do(UserEmailValidated e)
    {
        if (EmailInformation.Email.Equals(e.Email, StringComparison.OrdinalIgnoreCase))
        {
            List<BaseMessage> messages = [];
            User user = this;
            if (Status == UserStatus.PendingEmailConfirmation)
            {
                user = user with { Status = UserStatus.Enabled };
                messages.Add(new UserEnabled(e.Id));
            }

            if (EmailInformation.Validated)
            {
                messages.Add(BaseNotification.CreateInformation(
                    this,
                    "Email validation ignored.",
                    $"The email {EmailInformation.Email} was already validated.",
                    null));
            }

            messages.Add(e);
            return (user with
            {
                EmailInformation = new UserEmail(e.Email, true),
            }, messages);
        }

        return (this, [BaseNotification.CreateError(
            this,
            "Email validation failed",
            $"The email {e.Email} does not match the user's email.",
            null)]);
    }

    private (User Aggregate, IEnumerable<BaseMessage> Messages) Do(UserEnabled e)
    {
        if (Status == UserStatus.Enabled)
        {
            return (this, [BaseNotification.CreateInformation(
                    this,
                    "Enable user ignored.",
                    $"The user {Name} ({Id}) is already enabled.",
                    null)]);
        }

        return EmailInformation.Validated
                ? (this with { Status = UserStatus.Enabled }, [e])
                : (this with { Status = UserStatus.PendingEmailConfirmation, },
                    [BaseNotification.CreateInformation(
                        this,
                        "Enable user suspended.",
                        $"The user {Name} will be enabled once the email validation is received from {EmailInformation.Email}.",
                        null)]);
    }

    private (User Aggregate, IEnumerable<BaseMessage> Messages) Do(UserDisabled e)
    {
        return Status == UserStatus.Disabled
            ? (this, [BaseNotification.CreateInformation(
                    this,
                    "Disable user ignored.",
                    $"The user {Name} ({Id}) is already disabled",
                    null)])
            : (this with { Status = UserStatus.Disabled },
            [e]);
    }

    private (User Aggregate, IEnumerable<BaseMessage> Messages) Do(UserRegistered e)
    {
        if (IsInitialized())
        {
            return (this, [BaseNotification.CreateError(
                this,
                "User registration failed.",
                $"The user {Name} ({Id}) is already registered.",
                null)]);
        }

        return (new User(e), [e]);
    }
}