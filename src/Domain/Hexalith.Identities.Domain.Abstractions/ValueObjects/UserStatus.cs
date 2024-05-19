namespace Hexalith.Identities.Domain.ValueObjects;

/// <summary>
/// Represents the status of a user.
/// </summary>
public enum UserStatus
{
    /// <summary>
    /// The user is disabled.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// The user's email confirmation is pending.
    /// </summary>
    PendingEmailConfirmation = 1,

    /// <summary>
    /// The user is enabled.
    /// </summary>
    Enabled = 2,
}