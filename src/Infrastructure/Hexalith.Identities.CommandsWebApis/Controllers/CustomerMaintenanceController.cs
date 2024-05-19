// <copyright file="UserMaintenanceController.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Identities.CommandsWebApis.Controllers;

using Hexalith.Application.Aggregates;
using Hexalith.Infrastructure.WebApis.Controllers;
using Hexalith.Identities.Domain.Aggregates;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a controller for maintaining customer entities.
/// </summary>
/// <typeparam name="User">The type of the customer aggregate.</typeparam>
/// <seealso cref="AggregateMaintenanceController{User}" />
[ApiController]
[Route("customers")]
public class UserMaintenanceController(IAggregateMaintenance<User> aggregateMaintenance)
    : AggregateMaintenanceController<User>(aggregateMaintenance)
{
}