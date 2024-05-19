// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.DaprRuntime.Identities
// Author           : Jérôme Piquot
// Created          : 02-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-02-2023
// ***********************************************************************
// <copyright file="UserSettings.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Infrastructure.DaprRuntime.Identities.Configurations;

using Hexalith.Application.Configurations;
using Hexalith.Extensions.Configuration;
using Hexalith.Identities.Domain.Aggregates;

/// <summary>
/// Class InvoiceSettings.
/// Implements the <see cref="ISettings" />.
/// </summary>
/// <seealso cref="ISettings" />
public class UserSettings : ISettings
{
    /// <summary>
    /// Gets or sets the command processor.
    /// </summary>
    /// <value>The command processor.</value>
    public CommandProcessorSettings? CommandProcessor { get; set; }

    /// <summary>
    /// The configuration section name of the settings.
    /// </summary>
    /// <returns>The name.</returns>
    public static string ConfigurationName() => nameof(User);
}