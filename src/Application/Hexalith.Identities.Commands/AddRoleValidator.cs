namespace Hexalith.Identities.Commands;

using FluentValidation;

/// <summary>
/// Class AddRoleValidator.
/// Implements the <see cref="AbstractValidator{AddRole}" />.
/// </summary>
/// <seealso cref="AbstractValidator{AddRole}" />
public class AddRoleValidator : AbstractValidator<AddRole>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddRoleValidator"/> class.
    /// </summary>
    public AddRoleValidator()
    {
        _ = RuleFor(x => x.Id).NotEmpty();
        _ = RuleFor(x => x.Name).NotEmpty();
    }
}