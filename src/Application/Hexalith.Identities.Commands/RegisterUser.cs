namespace Hexalith.Identities.Commands;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Extensions;
using Hexalith.Identities.Domain.ValueObjects;

/// <summary>
/// The register user command.
/// Implements the <see cref="Hexalith.Identities.Commands.UserCommand" />.
/// </summary>
/// <seealso cref="Hexalith.Identities.Commands.UserCommand" />
[DataContract]
public class RegisterUser : UserCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUser"/> class.
    /// </summary>
    /// <param name="id">The user ID.</param>
    /// <param name="name">The user name.</param>
    /// <param name="email">The user email.</param>
    /// <param name="globalization">The user time zone and language.</param>
    /// <param name="externalIdentity">The user external identities.</param>
    /// <param name="login">The user login and password hash.</param>
    [JsonConstructor]
    public RegisterUser(
        string id,
        string name,
        string email,
        UserGlobalization globalization,
        ExternalIdentity? externalIdentity,
        UserLogin? login)
        : base(id)
    {
        Name = name;
        Email = email;
        Globalization = globalization;
        ExternalIdentity = externalIdentity;
        Login = login;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUser"/> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public RegisterUser()
    {
        Name = string.Empty;
        Globalization = new UserGlobalization();
    }

    /// <summary>
    /// Gets or sets the user email.
    /// </summary>
    [DataMember(Order = 11)]
    public string Email { get; set; }

    /// <summary>
    /// Gets the user external identity.
    /// </summary>
    [DataMember(Order = 13)]
    public ExternalIdentity? ExternalIdentity { get; }

    /// <summary>
    /// Gets the user language.
    /// </summary>
    [DataMember(Order = 12)]
    public UserGlobalization Globalization { get; }

    /// <summary>
    /// Gets the user login.
    /// </summary>
    [DataMember(Order = 14)]
    public UserLogin? Login { get; }

    /// <summary>
    /// Gets or sets the user name.
    /// </summary>
    [DataMember(Order = 10)]
    public string Name { get; set; }
}