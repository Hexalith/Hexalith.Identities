﻿// <copyright file="PersistentAuthenticationStateProvider.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Identities.ClientAppOnWasm;

using System.Security.Claims;

using Hexalith.Identities.Security.Abstractions.ViewModels;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

// This is a client-side AuthenticationStateProvider that determines the user's authentication state by
// looking for data persisted in the page when it was rendered on the server. This authentication state will
// be fixed for the lifetime of the WebAssembly application. So, if the user needs to log in or out, a full
// page reload is required.
//
// This only provides a user name and email for display purposes. It does not actually include any tokens
// that authenticate to the server when making subsequent requests. That works separately using a
// cookie that will be included on HttpClient requests to the server.

/// <summary>
/// Persistent authentication state provider.
/// Implements the <see cref="AuthenticationStateProvider" />.
/// </summary>
/// <seealso cref="AuthenticationStateProvider" />
internal class PersistentAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly Task<AuthenticationState> DefaultUnauthenticatedTask =
        Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

    private readonly Task<AuthenticationState> _authenticationStateTask = DefaultUnauthenticatedTask;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersistentAuthenticationStateProvider"/> class.
    /// </summary>
    /// <param name="state"></param>
    public PersistentAuthenticationStateProvider(PersistentComponentState state)
    {
        if (!state.TryTakeFromJson(nameof(UserViewModel), out UserViewModel? userInfo) || userInfo is null)
        {
            return;
        }

        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, userInfo.Id),
            new Claim(ClaimTypes.Name, userInfo.Email),
            new Claim(ClaimTypes.Email, userInfo.Email)];

        _authenticationStateTask = Task.FromResult(
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(
                claims,
                authenticationType: nameof(PersistentAuthenticationStateProvider)))));
    }

    /// <inheritdoc/>
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => _authenticationStateTask;
}