namespace Hexalith.Identities.Events.Users;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;

/// <summary>
/// The user email validated event.
/// Implements the <see cref="UserEvent" />.
/// </summary>
/// <seealso cref="UserEvent" />
[DataContract]
public class UserEmailValidated : UserEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEmailValidated"/> class.
    /// </summary>
    /// <param name="id">The user ID.</param>
    /// <param name="email">The user validated email.</param>
    [JsonConstructor]
    public UserEmailValidated(
        string id,
        string email)
        : base(id) => Email = email;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserEmailValidated"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public UserEmailValidated()
    {
    }

    /// <summary>
    /// Gets or sets the user validated email.
    /// </summary>
    [DataMember(Order = 10)]
    public string? Email { get; set; }
}