namespace Hexalith.Identities.EventsWebApis.Users.Projections;

using Hexalith.Domain.Events;
using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for user snapshot event.
/// </summary>
public sealed class UserSnapshotHandler(IActorProjectionFactory<User> factory)
    : AggregateProjectionUpdateEventHandler<SnapshotEvent, User>(factory)
{
}