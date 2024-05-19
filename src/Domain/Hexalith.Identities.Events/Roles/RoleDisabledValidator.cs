namespace Hexalith.Identities.Events.Roles;

using FluentValidation;

/// <summary>
/// The role disabled event validator.
/// Implements the <see cref="AbstractValidator{RoleDisabled}" />.
/// </summary>
/// <seealso cref="AbstractValidator{RoleDisabled}" />
public class RoleDisabledValidator : AbstractValidator<RoleDisabled>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleDisabledValidator"/> class.
    /// </summary>
    public RoleDisabledValidator() => _ = RuleFor(x => x.Id).NotEmpty();
}