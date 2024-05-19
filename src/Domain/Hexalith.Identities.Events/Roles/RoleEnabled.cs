namespace Hexalith.Identities.Events.Roles;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;
using Hexalith.Identities.Events.Roles;

/// <summary>
/// The role email enabled event.
/// Implements the <see cref="RoleEvent" />.
/// </summary>
/// <seealso cref="RoleEvent" />
[DataContract]
public class RoleEnabled : RoleEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleEnabled"/> class.
    /// </summary>
    /// <param name="id">The role ID.</param>
    [JsonConstructor]
    public RoleEnabled(
        string id)
        : base(id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleEnabled"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public RoleEnabled()
    {
    }
}