namespace Hexalith.Identities.Commands;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Application.Commands;
using Hexalith.Extensions;
using Hexalith.Identities.Domain.Helpers;

/// <summary>
/// The role command base class.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
[DataContract]
public class RoleCommand : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleCommand"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected RoleCommand(string id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleCommand" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected RoleCommand() => Id = string.Empty;

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