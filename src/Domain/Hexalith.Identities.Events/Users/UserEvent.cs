namespace Hexalith.Identities.Events.Users;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Domain.Events;
using Hexalith.Extensions;
using Hexalith.Identities.Domain.Helpers;

/// <summary>
/// The user event base class.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[DataContract]
public class UserEvent : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEvent"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected UserEvent(string id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserEvent" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected UserEvent() => Id = string.Empty;

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public string Id { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId()
        => IdentitiesDomainHelper.GetUserAggregateId(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName()
        => IdentitiesDomainHelper.UserAggregateName;
}