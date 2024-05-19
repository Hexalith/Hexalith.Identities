// <copyright file="UserRoleMembershipAction.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

using Hexalith.Application.Authorizations;
using Hexalith.Application.Modules;

namespace Hexalith.Identities.Application.Modules;

/// <summary>
/// Represents an action to add a role to a user.
/// </summary>
public sealed class UserRoleMembershipAction : IApplicationAction
{
    private static IApplicationModule? _parentModule;

    /// <summary>
    /// Gets the description of the action.
    /// </summary>
    public static string Description => "Manage user role membership";

    /// <summary>
    /// Gets the name of the action.
    /// </summary>
    public static string Name => "User roles";

    /// <summary>
    /// Gets the parent module for this action.
    /// </summary>
    /// <value>The parent module.</value>
    public static IApplicationModule ParentModule => _parentModule ??= new AuthorizationModule();

    /// <summary>
    /// Gets the path of the action.
    /// </summary>
    public static string Path => AuthorizationModule.Path + "/user/roles";

    /// <summary>
    /// Gets the role associated with the action.
    /// </summary>
    public static string Role => RoleRoles.AssignRoleToUser;

    /// <inheritdoc/>
    string IApplicationAction.Description => Description;

    /// <inheritdoc/>
    string IApplicationAction.Name => Name;

    /// <inheritdoc/>
    IApplicationModule IApplicationAction.ParentModule => ParentModule;

    /// <inheritdoc/>
    string IApplicationAction.Path => Path;

    /// <inheritdoc/>
    string IApplicationAction.Role => Role;
}