// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.DaprRuntime.User
// Author           : Jérôme Piquot
// Created          : 09-12-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 10-15-2023
// ***********************************************************************
// <copyright file="IdentitiesHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Infrastructure.DaprRuntime.Identities.Helpers;

using System.Diagnostics.CodeAnalysis;

using Hexalith.Extensions.Configuration;
using Hexalith.Identities.Application.Helpers;
using Hexalith.Infrastructure.DaprRuntime.Identities.Configurations;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Class IdentitiesHelper.
/// </summary>
public static class IdentitiesHelper
{
    /// <summary>
    /// Adds the parties.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddDaprIdentities([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        _ = services
            .AddIdentitiesCommandHandlers()
            .ConfigureSettings<UserSettings>(configuration);
        return services;
    }

    /// <summary>
    /// Adds the dapr parties client.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="System.ArgumentNullException">null.</exception>
    public static IServiceCollection AddDaprIdentitiesClient([NotNull] this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        return services;
    }
}