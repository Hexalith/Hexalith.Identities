namespace Hexalith.Identities.Events.Users;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;

/// <summary>
/// The user email enabled event.
/// Implements the <see cref="UserEvent" />.
/// </summary>
/// <seealso cref="UserEvent" />
[DataContract]
public class UserEnabled : UserEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEnabled"/> class.
    /// </summary>
    /// <param name="id">The user ID.</param>
    [JsonConstructor]
    public UserEnabled(
        string id)
        : base(id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserEnabled"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public UserEnabled()
    {
    }
}