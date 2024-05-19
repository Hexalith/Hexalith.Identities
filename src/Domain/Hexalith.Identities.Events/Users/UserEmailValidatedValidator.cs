namespace Hexalith.Identities.Events.Users;

using FluentValidation;

/// <summary>
/// Class UserEmailValidatedValidator.
/// Implements the <see cref="AbstractValidator{UserEmailValidated}" />.
/// </summary>
/// <seealso cref="AbstractValidator{UserEmailValidated}" />
public class UserEmailValidatedValidator : AbstractValidator<UserEmailValidated>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEmailValidatedValidator"/> class.
    /// </summary>
    public UserEmailValidatedValidator()
    {
        _ = RuleFor(x => x.Id).NotEmpty();
        _ = RuleFor(x => x.Email).NotEmpty();
    }
}