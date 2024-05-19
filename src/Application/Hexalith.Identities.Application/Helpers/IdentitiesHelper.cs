// ***********************************************************************
// Assembly         : Hexalith.Application.Identities
// Author           : Jérôme Piquot
// Created          : 09-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-04-2023
// ***********************************************************************
// <copyright file="IdentitiesHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Identities.Application.Helpers;

using FluentValidation;

using Hexalith.Application.Commands;
using Hexalith.Identities.Application.CommandHandlers;
using Hexalith.Identities.Commands;
using Hexalith.Identities.Events.Roles;
using Hexalith.Identities.Events.Users;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Class IdentitiesHelper.
/// </summary>
public static class IdentitiesHelper
{
    /// <summary>
    /// Adds the parties command handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddIdentitiesCommandHandlers(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandHandler<AddRole>, AddRoleHandler>();
        services.TryAddScoped<ICommandHandler<RegisterUser>, RegisterUserHandler>();
        return services.AddIdentitiesEventValidators();
    }

    /// <summary>
    /// Adds the parties event validators.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddIdentitiesEventValidators(this IServiceCollection services)
    {
        services.TryAddSingleton<IValidator<UserRegistered>, UserRegisteredValidator>();
        services.TryAddSingleton<IValidator<RoleAdded>, RoleAddedValidator>();
        return services;
    }
}