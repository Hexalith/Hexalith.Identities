namespace Hexalith.Identities.Events.Users;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;

/// <summary>
/// The user email disabled event.
/// Implements the <see cref="UserEvent" />.
/// </summary>
/// <seealso cref="UserEvent" />
[DataContract]
public class UserDisabled : UserEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDisabled"/> class.
    /// </summary>
    /// <param name="id">The user ID.</param>
    [JsonConstructor]
    public UserDisabled(
        string id)
        : base(id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserDisabled"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public UserDisabled()
    {
    }
}