namespace Hexalith.Identities.Commands;

using FluentValidation;

/// <summary>
/// Class RegisterUserValidator.
/// Implements the <see cref="AbstractValidator{RegisterUser}" />.
/// </summary>
/// <seealso cref="AbstractValidator{RegisterUser}" />
public class RegisterUserValidator : AbstractValidator<RegisterUser>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserValidator"/> class.
    /// </summary>
    public RegisterUserValidator()
    {
        _ = RuleFor(x => x.Id).NotEmpty();
        _ = RuleFor(x => x.Name).NotEmpty();
        _ = RuleFor(x => x.Email).NotEmpty();
        _ = RuleFor(x => x.Globalization).NotNull();
        _ = RuleFor(x => x.Globalization.Language).NotEmpty();
        _ = RuleFor(x => x.Globalization.TimeZone).NotNull();
    }
}