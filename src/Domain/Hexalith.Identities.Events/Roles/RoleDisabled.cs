namespace Hexalith.Identities.Events.Roles;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;
using Hexalith.Identities.Events.Roles;

/// <summary>
/// The role email disabled event.
/// Implements the <see cref="RoleEvent" />.
/// </summary>
/// <seealso cref="RoleEvent" />
[DataContract]
public class RoleDisabled : RoleEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleDisabled"/> class.
    /// </summary>
    /// <param name="id">The role ID.</param>
    [JsonConstructor]
    public RoleDisabled(
        string id)
        : base(id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleDisabled"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public RoleDisabled()
    {
    }
}