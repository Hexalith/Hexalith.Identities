namespace Hexalith.Identities.Events.Roles;

using FluentValidation;

/// <summary>
/// The role enabled event validator.
/// Implements the <see cref="AbstractValidator{RoleEnabled}" />.
/// </summary>
/// <seealso cref="AbstractValidator{RoleEnabled}" />
public class RoleEnabledValidator : AbstractValidator<RoleEnabled>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleEnabledValidator"/> class.
    /// </summary>
    public RoleEnabledValidator() => _ = RuleFor(x => x.Id).NotEmpty();
}