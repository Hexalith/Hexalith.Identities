// <copyright file="Role.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Identities.Domain.Aggregates;

using System;
using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Messages;
using Hexalith.Domain.Notifications;
using Hexalith.Domain.Users.Models;
using Hexalith.Identities.Domain.Helpers;
using Hexalith.Identities.Events.Roles;

/// <summary>
/// Represents a role.
/// Implements the <see cref="Aggregate" />
/// Implements the <see cref="IAggregate" />.
/// </summary>
/// <seealso cref="Aggregate" />
/// <seealso cref="IAggregate" />
[DataContract]
public record Role(
    [property: DataMember(Order = 1)] string Id,
    [property: DataMember(Order = 2)] string Name,
    [property: DataMember(Order = 3)] string Description,
    [property: DataMember(Order = 3)] bool Enabled)
    : Aggregate, IRole
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    /// <param name="added">The role added event.</param>
    public Role(RoleAdded added)
        : this(
             (added ?? throw new ArgumentNullException(nameof(added))).Id,
             added.Name,
             added.Description ?? string.Empty,
             true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    public Role()
        : this(string.Empty, string.Empty, string.Empty, false)
    {
    }

    /// <inheritdoc/>
    public override (IAggregate Aggregate, IEnumerable<BaseMessage> Messages) Apply(BaseEvent domainEvent)
    {
        CheckValid(domainEvent);
        return domainEvent switch
        {
            RoleAdded e => Do(e),
            RoleEnabled e => Do(e),
            RoleDisabled e => Do(e),
            _ => base.Apply(domainEvent),
        };
    }

    /// <inheritdoc/>
    public override bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => IdentitiesDomainHelper.GetRoleAggregateId(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => IdentitiesDomainHelper.RoleAggregateName;

    private (Role Aggregate, IEnumerable<BaseMessage> Messages) Do(RoleEnabled e)
    {
        if (Enabled)
        {
            return (this, [BaseNotification.CreateInformation(
                    this,
                    "Enable role ignored.",
                    $"The role {Name} ({Id}) is already enabled.",
                    null)]);
        }

        return (this with { Enabled = true }, [e]);
    }

    private (Role Aggregate, IEnumerable<BaseMessage> Messages) Do(RoleDisabled e)
    {
        return !Enabled
            ? (this, [BaseNotification.CreateInformation(
                    this,
                    "Disable role ignored.",
                    $"The role {Name} ({Id}) is already disabled",
                    null)])
            : (this with { Enabled = true }, [e]);
    }

    private (Role Aggregate, IEnumerable<BaseMessage> Messages) Do(RoleAdded e)
    {
        if (IsInitialized())
        {
            return (this, [BaseNotification.CreateError(
                this,
                "Role not added.",
                $"The role {Name} ({Id}) already exist.",
                null)]);
        }

        return (new Role(e), [e]);
    }
}