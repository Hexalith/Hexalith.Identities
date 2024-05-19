namespace Hexalith.Identities.EventsWebApis.Roles.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Roles;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for added role event.
/// </summary>
public sealed class RoleAddedProjectionUpdateHandler(IActorProjectionFactory<Role> factory)
    : AggregateProjectionUpdateEventHandler<RoleAdded, Role>(factory)
{
}