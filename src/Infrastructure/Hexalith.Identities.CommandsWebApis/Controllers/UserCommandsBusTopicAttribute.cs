// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.ExternalSystemsCommands
// Author           : Jérôme Piquot
// Created          : 11-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 11-04-2023
// ***********************************************************************
// <copyright file="UserCommandsBusTopicAttribute.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Identities.CommandsWebApis.Controllers;

using Hexalith.Identities.Domain.Helpers;
using Hexalith.Infrastructure.WebApis.Buses;

/// <summary>
/// Class UserCommandsBusTopicAttribute. This class cannot be inherited.
/// Implements the <see cref="CommandBusTopicAttribute" />.
/// </summary>
/// <seealso cref="CommandBusTopicAttribute" />
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class UserCommandsBusTopicAttribute : CommandBusTopicAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserCommandsBusTopicAttribute"/> class.
    /// </summary>
    public UserCommandsBusTopicAttribute()
        : base(IdentitiesDomainHelper.UserAggregateName)
    {
    }
}