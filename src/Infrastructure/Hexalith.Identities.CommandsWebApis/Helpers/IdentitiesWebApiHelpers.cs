// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.Identities
// Author           : Jérôme Piquot
// Created          : 10-27-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 10-27-2023
// ***********************************************************************
// <copyright file="IdentitiesWebApiHelpers.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Identities.CommandsWebApis.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Client;

using Hexalith.Application.Aggregates;
using Hexalith.Application.Commands;
using Hexalith.Infrastructure.DaprRuntime.CosmosDatabases.Maintenances;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Identities.Application.Helpers;
using Hexalith.Identities.CommandsWebApis.Controllers;
using Hexalith.Identities.Domain.Aggregates;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class IdentitiesWebApiHelpers.
/// </summary>
public static class IdentitiesWebApiHelpers
{
    /// <summary>
    /// Adds the external systems integration event handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddIdentitiesCommandsSubmission([NotNull] this IServiceCollection services)
    {
        services
            .AddIdentitiesCommandHandlers()
            .TryAddSingleton<ICommandProcessor>((s) => new AggregateActorCommandProcessor(
                ActorProxy.DefaultProxyFactory,
                s.GetRequiredService<ILogger<AggregateActorCommandProcessor>>()));

        services.TryAddSingleton<IAggregateFactory, AggregateFactory>();
        services.TryAddSingleton<IAggregateProvider, AggregateProvider<User>>();
        services.TryAddTransient<IAggregateMaintenance<User>, DaprCosmosAggregateMaintenance<User>>();
        _ = services
         .AddControllers()
         .AddApplicationPart(typeof(IdentitiesCommandsController).Assembly)
         .AddDapr();
        return services;
    }
}