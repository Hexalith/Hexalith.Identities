namespace Hexalith.Identities.Domain.ValueObjects;

using System.Runtime.Serialization;

/// <summary>
/// Represents an external identity.
/// </summary>
[DataContract]
public record ExternalIdentity(
    /// <summary>
    /// Gets the ID of the external identity.
    /// </summary>
    [property: DataMember(Order = 1)]
    string Id,

    /// <summary>
    /// Gets the name of the external identity.
    /// </summary>
    [property: DataMember(Order = 2)]
    string Name,

    /// <summary>
    /// Gets the authority of the external identity.
    /// </summary>
    [property: DataMember(Order = 3)]
    string Authority)
{
}