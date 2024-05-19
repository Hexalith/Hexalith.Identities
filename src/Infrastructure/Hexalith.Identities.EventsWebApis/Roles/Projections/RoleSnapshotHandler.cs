namespace Hexalith.Identities.EventsWebApis.Roles.Projections;

using Hexalith.Domain.Events;
using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for user snapshot event.
/// </summary>
public sealed class RoleSnapshotHandler(IActorProjectionFactory<Role> factory)
    : AggregateProjectionUpdateEventHandler<SnapshotEvent, Role>(factory)
{
}