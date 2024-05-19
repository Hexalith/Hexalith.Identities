namespace Hexalith.Identities.Domain.ValueObjects;

using System.Runtime.Serialization;

/// <summary>
/// Represents a user login information.
/// </summary>
[DataContract]
public record UserLogin(
    /// <summary>
    /// Gets the login username.
    /// </summary>
    [property:DataMember(Order = 1)]
    string Login,
    /// <summary>
    /// Gets the password hash.
    /// </summary>
    [property:DataMember(Order = 2)]
    long PasswordHash)
{
}