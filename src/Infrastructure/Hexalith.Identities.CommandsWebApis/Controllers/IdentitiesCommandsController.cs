// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.IdentitiesCommands
// Author           : Jérôme Piquot
// Created          : 10-27-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 10-29-2023
// ***********************************************************************
// <copyright file="IdentitiesCommandsController.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Identities.CommandsWebApis.Controllers;

using Dapr;

using Hexalith.Application.Commands;
using Hexalith.Application.States;
using Hexalith.Infrastructure.WebApis.Controllers;
using Hexalith.Identities.Domain.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class IdentitiesPubSubController.
/// Implements the <see cref="CommandIntegrationController" />.
/// </summary>
/// <seealso cref="CommandIntegrationController" />
/// <remarks>
/// Initializes a new instance of the <see cref="IdentitiesCommandsController" /> class.
/// </remarks>
/// <param name="commandProcessor">The command processor.</param>
/// <param name="hostEnvironment">The host environment.</param>
/// <param name="logger">The logger.</param>
[ApiController]
public class IdentitiesCommandsController(
    ICommandProcessor commandProcessor,
    IHostEnvironment hostEnvironment,
    ILogger<IdentitiesCommandsController> logger) : CommandSubmissionController(commandProcessor, hostEnvironment, logger)
{
    /// <summary>
    /// Handle external systems commands as an asynchronous operation.
    /// </summary>
    /// <param name="commandState">State of the command.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [UserCommandsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-customer-commands")]
    public async Task<ActionResult> SubmitUserCommandsAsync(CommandState commandState)
        => await HandleCommandAsync(
                commandState,
                IdentitiesDomainHelper.UserAggregateName,
                CancellationToken.None)
            .ConfigureAwait(false);
}