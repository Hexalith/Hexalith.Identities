namespace Hexalith.Identities.Events.Roles;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Domain.Events;
using Hexalith.Extensions;
using Hexalith.Identities.Domain.Helpers;

/// <summary>
/// The role event base class.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[DataContract]
public class RoleEvent : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleEvent"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected RoleEvent(string id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleEvent" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected RoleEvent() => Id = string.Empty;

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public string Id { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId()
        => IdentitiesDomainHelper.GetRoleAggregateId(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName()
        => IdentitiesDomainHelper.RoleAggregateName;
}