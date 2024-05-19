namespace Hexalith.Identities.EventsWebApis.Roles.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Roles;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for role enabling event.
/// </summary>
public sealed class RoleEnabledProjectionUpdateHandler(IActorProjectionFactory<Role> factory)
    : AggregateProjectionUpdateEventHandler<RoleEnabled, Role>(factory)
{
}