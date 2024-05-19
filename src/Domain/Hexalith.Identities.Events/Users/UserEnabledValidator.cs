namespace Hexalith.Identities.Events.Users;

using FluentValidation;

/// <summary>
/// The user enabled event validator.
/// Implements the <see cref="AbstractValidator{UserEnabled}" />.
/// </summary>
/// <seealso cref="AbstractValidator{UserEnabled}" />
public class UserEnabledValidator : AbstractValidator<UserEnabled>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEnabledValidator"/> class.
    /// </summary>
    public UserEnabledValidator() => _ = RuleFor(x => x.Id).NotEmpty();
}