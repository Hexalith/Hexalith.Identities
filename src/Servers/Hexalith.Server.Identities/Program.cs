// <copyright file="Program.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

using Hexalith.Infrastructure.WebApis.Helpers;
using Hexalith.Identities.CommandsWebApis.Helpers;
using Hexalith.Identities.DaprRuntime.Helpers;
using Hexalith.Server.Identities;

WebApplicationBuilder builder = HexalithWebApi.CreateApplication(
    IdentitiesConstants.ApplicationName,
    "v1",
    (actors) => actors.AddIdentitiesAggregates(),
    args);

builder.Services.AddIdentitiesCommandsSubmission();

await builder
    .Build()
    .UseHexalith<Program>(IdentitiesConstants.ApplicationName)
    .RunAsync()
    .ConfigureAwait(false);