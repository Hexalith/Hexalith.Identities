// <copyright file="AuthorizationModule.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Identities.Application.Modules;

using System.Collections.Generic;

using Hexalith.Application.Modules.Modules;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Represents the authorization module details.
/// </summary>
public sealed class AuthorizationModule : IApplicationModule
{
    /// <summary>
    /// Gets the description of the authorization module.
    /// </summary>
    public const string Description = "Manage application roles membership";

    /// <summary>
    /// Gets the name of the authorization module.
    /// </summary>
    public const string Name = "Authorization management";

    /// <summary>
    /// Gets the path of the authorization module.
    /// </summary>
    public const string Path = "/authorization";

    /// <summary>
    /// Gets the version of the authorization module.
    /// </summary>
    public const string Version = "1.0";

    public IEnumerable<string> Dependencies { get; }

    public string Id { get; }

    public ModuleType ModuleType { get; }

    public int OrderWeight { get; set; }

    /// <inheritdoc/>
    string IApplicationModule.Description => Description;

    /// <inheritdoc/>
    string IApplicationModule.Name => Name;

    /// <inheritdoc/>
    string IApplicationModule.Path => Path;

    /// <inheritdoc/>
    string IApplicationModule.Version => Version;

    public void AddServices(IServiceCollection services, IConfiguration configuration) => throw new NotImplementedException();
}