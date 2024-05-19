// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.DaprRuntime.User
// Author           : Jérôme Piquot
// Created          : 09-12-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 10-29-2023
// ***********************************************************************
// <copyright file="IdentitiesActorsHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Identities.DaprRuntime.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Runtime;

using Hexalith.Infrastructure.DaprRuntime.Helpers;
using Hexalith.Infrastructure.DaprRuntime.Sales.Actors;
using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Domain.Helpers;

/// <summary>
/// Class IdentitiesHelper.
/// </summary>
public static class IdentitiesActorsHelper
{
    /// <summary>
    /// Adds the parties.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static ActorRegistrationCollection AddIdentitiesAggregates([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<AggregateActor>(AggregateActorBase.GetAggregateActorName(IdentitiesDomainHelper.UserAggregateName));
        return actors;
    }

    /// <summary>
    /// Adds the parties projections.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <param name="applicationId">Name of the application.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static ActorRegistrationCollection AddIdentitiesProjections([NotNull] this ActorRegistrationCollection actors, string applicationId)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterProjectionActor<User>(applicationId);
        return actors;
    }
}