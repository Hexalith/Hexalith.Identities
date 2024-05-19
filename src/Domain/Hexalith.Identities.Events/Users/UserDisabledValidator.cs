namespace Hexalith.Identities.Events.Users;

using FluentValidation;

/// <summary>
/// The user disabled event validator.
/// Implements the <see cref="AbstractValidator{UserDisabled}" />.
/// </summary>
/// <seealso cref="AbstractValidator{UserDisabled}" />
public class UserDisabledValidator : AbstractValidator<UserDisabled>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDisabledValidator"/> class.
    /// </summary>
    public UserDisabledValidator() => _ = RuleFor(x => x.Id).NotEmpty();
}