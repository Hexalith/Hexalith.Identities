namespace Hexalith.Identities.Commands;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;

/// <summary>
/// The role registered command.
/// Implements the <see cref="Hexalith.Identities.Commands.RoleCommand" />.
/// </summary>
/// <seealso cref="Hexalith.Identities.Commands.RoleCommand" />
[DataContract]
public class AddRole : RoleCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddRole"/> class.
    /// </summary>
    /// <param name="id">The role ID.</param>
    /// <param name="name">The role name.</param>
    /// <param name="description">The role description.</param>
    [JsonConstructor]
    public AddRole(
        string id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AddRole"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public AddRole() => Name = Description = string.Empty;

    /// <summary>
    /// Gets or sets the role description.
    /// </summary>
    [DataMember(Order = 11)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the role name.
    /// </summary>
    [DataMember(Order = 10)]
    public string Name { get; set; }
}