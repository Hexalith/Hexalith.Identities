namespace Hexalith.Identities.Domain.ValueObjects;

using System.Runtime.Serialization;

/// <summary>
/// The user email information.
/// Implements the <see cref="System.IEquatable{Hexalith.Identities.Domain.ValueObjects.UserEmail}" />.
/// </summary>
/// <seealso cref="System.IEquatable{Hexalith.Identities.Domain.ValueObjects.UserEmail}" />
[DataContract]
public record UserEmail(
    /// <summary>
    /// The user email.
    /// </summary>
    [property: DataMember(Order = 1)] string Email,
    /// <summary>
    /// The user email validation status.
    /// </summary>
    [property: DataMember(Order = 2)] bool Validated)
{
}