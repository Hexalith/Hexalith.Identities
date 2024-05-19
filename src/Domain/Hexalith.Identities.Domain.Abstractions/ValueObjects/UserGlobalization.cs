namespace Hexalith.Identities.Domain.ValueObjects;

using System;
using System.Globalization;
using System.Runtime.Serialization;

/// <summary>
/// User globalization and localization settings
/// Implements the <see cref="System.IEquatable{Hexalith.Identities.Domain.ValueObjects.UserGlobalization}" />.
/// </summary>
/// <seealso cref="System.IEquatable{Hexalith.Identities.Domain.ValueObjects.UserGlobalization}" />
[DataContract]
public record UserGlobalization(
    /// <summary>
    /// The user language (fr-FR, en-US, etc.).
    /// </summary>
    [property: DataMember(Order = 4)] string Language,
    /// <summary>
    /// The user time zone.
    /// </summary>
    [property: DataMember(Order = 5)] TimeZoneInfo TimeZone)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserGlobalization"/> class.
    /// </summary>
    public UserGlobalization()
        : this(
        CultureInfo.CurrentCulture.Name,
        TimeZoneInfo.Local)
    {
    }
}