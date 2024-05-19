namespace Hexalith.Identities.EventsWebApis.Users.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Users;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for user disabling event.
/// </summary>
public sealed class UserDisabledProjectionUpdateHandler(IActorProjectionFactory<User> factory)
    : AggregateProjectionUpdateEventHandler<UserDisabled, User>(factory)
{
}