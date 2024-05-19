// ***********************************************************************
// Assembly         : Hexalith.Application.Identities
// Author           : Jérôme Piquot
// Created          : 08-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 12-21-2023
// ***********************************************************************
// <copyright file="AddRoleHandler.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Identities.Application.CommandHandlers;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.Application.Commands;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Messages;
using Hexalith.Identities.Commands;
using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Roles;

/// <summary>
/// Class AddRoleHandler.
/// Implements the <see cref="CommandHandler{Hexalith.Application.Identities.Commands.AddRole}" />.
/// </summary>
/// <seealso cref="CommandHandler{Hexalith.Application.Identities.Commands.AddRole}" />
public class AddRoleHandler : CommandHandler<AddRole>
{
    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> DoAsync(
        [NotNull] AddRole command,
        IAggregate? aggregate,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        RoleAdded added =
            new(
                command.Id,
                command.Name,
                command.Description);
        (_, IEnumerable<BaseMessage>? events) = (aggregate ?? new Role()).Apply(added);
        return await Task.FromResult(events).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> UndoAsync(AddRole command, IAggregate? aggregate, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        throw new NotSupportedException();
    }
}