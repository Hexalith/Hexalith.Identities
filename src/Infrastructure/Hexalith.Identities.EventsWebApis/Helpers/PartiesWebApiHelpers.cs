namespace Hexalith.Identities.EventsWebApis.Helpers;

using Hexalith.Application.Projections;
using Hexalith.Domain.Events;
using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Users;
using Hexalith.Identities.EventsWebApis.Controllers;
using Hexalith.Infrastructure.DaprRuntime.Helpers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Class IdentitiesWebApiHelpers.
/// </summary>
public static class IdentitiesWebApiHelpers
{
    /// <summary>
    /// Adds the customer projections.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="applicationId">Name of the application.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static IServiceCollection AddUserProjections(this IServiceCollection services, string applicationId)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(applicationId);
        services.TryAddScoped<IProjectionUpdateHandler<SnapshotEvent>, IdentitiesSnapshotHandler>();
        services.TryAddScoped<IProjectionUpdateHandler<UserRegistered>, UserRegisteredProjectionUpdateHandler>();
        _ = services.AddActorProjectionFactory<User>(applicationId);
        _ = services
         .AddControllers()
         .AddApplicationPart(typeof(UserIntegrationEventsController).Assembly)
         .AddDapr();
        return services;
    }
}