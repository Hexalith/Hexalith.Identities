namespace Hexalith.Identities.Domain.Helpers;

using Hexalith.Domain.Aggregates;

/// <summary>
/// Inventory helper.
/// </summary>
public static class IdentitiesDomainHelper
{
    /// <summary>
    /// Gets the identifier separator.
    /// </summary>
    /// <value>The identifier separator.</value>
    public static char IdSeparator => '-';

    /// <summary>
    /// Gets the aggregate name for the Role.
    /// </summary>
    public static string RoleAggregateName => "Role";

    /// <summary>
    /// Gets the aggregate name for the User.
    /// </summary>
    public static string UserAggregateName => "User";

    /// <summary>
    /// Gets the aggregate ID for the Role.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <returns>The aggregate ID.</returns>
    public static string GetRoleAggregateId(string id)
        => Aggregate.Normalize(UserAggregateName + IdSeparator + id);

    /// <summary>
    /// Gets the aggregate ID for the User.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <returns>The aggregate ID.</returns>
    public static string GetUserAggregateId(string id)
        => Aggregate.Normalize(UserAggregateName + IdSeparator + id);
}