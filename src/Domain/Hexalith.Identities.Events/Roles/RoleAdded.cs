namespace Hexalith.Identities.Events.Roles;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;

/// <summary>
/// The role registered event.
/// Implements the <see cref="RoleEvent" />.
/// </summary>
/// <seealso cref="RoleEvent" />
[DataContract]
public class RoleAdded : RoleEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleAdded"/> class.
    /// </summary>
    /// <param name="id">The role ID.</param>
    /// <param name="name">The role name.</param>
    /// <param name="description">The role description.</param>
    [JsonConstructor]
    public RoleAdded(
        string id,
        string name,
        string? description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleAdded"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public RoleAdded() => Name = string.Empty;

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