namespace Hexalith.Identities.EventsWebApis.Users.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Users;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for user enabling event.
/// </summary>
public sealed class UserEnabledProjectionUpdateHandler(IActorProjectionFactory<User> factory)
    : AggregateProjectionUpdateEventHandler<UserEnabled, User>(factory)
{
}