namespace Hexalith.Identities.Commands;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Application.Commands;
using Hexalith.Extensions;
using Hexalith.Identities.Domain.Helpers;

/// <summary>
/// The user command base class.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
[DataContract]
public class UserCommand : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserCommand"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected UserCommand(string id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserCommand" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected UserCommand() => Id = string.Empty;

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