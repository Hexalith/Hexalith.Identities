namespace Hexalith.Identities.Events.Users;

using FluentValidation;

/// <summary>
/// Class UserRegisteredValidator.
/// Implements the <see cref="AbstractValidator{UserRegistered}" />.
/// </summary>
/// <seealso cref="AbstractValidator{UserRegistered}" />
public class UserRegisteredValidator : AbstractValidator<UserRegistered>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegisteredValidator"/> class.
    /// </summary>
    public UserRegisteredValidator()
    {
        _ = RuleFor(x => x.Id).NotEmpty();
        _ = RuleFor(x => x.Name).NotEmpty();
        _ = RuleFor(x => x.Email).NotEmpty();
        _ = RuleFor(x => x.Globalization).NotNull();
        _ = RuleFor(x => x.Globalization.Language).NotEmpty();
        _ = RuleFor(x => x.Globalization.TimeZone).NotNull();
    }
}