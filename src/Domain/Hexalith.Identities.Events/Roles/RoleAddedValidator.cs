namespace Hexalith.Identities.Events.Roles;

using FluentValidation;

/// <summary>
/// Class RoleAddedValidator.
/// Implements the <see cref="AbstractValidator{RoleAdded}" />.
/// </summary>
/// <seealso cref="AbstractValidator{RoleAdded}" />
public class RoleAddedValidator : AbstractValidator<RoleAdded>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleAddedValidator"/> class.
    /// </summary>
    public RoleAddedValidator()
    {
        _ = RuleFor(x => x.Id).NotEmpty();
        _ = RuleFor(x => x.Name).NotEmpty();
    }
}