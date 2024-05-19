namespace Hexalith.Identities.EventsWebApis.Users.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Users;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for user registration event.
/// </summary>
public sealed class UserRegisteredProjectionUpdateHandler(IActorProjectionFactory<User> factory)
    : AggregateProjectionUpdateEventHandler<UserRegistered, User>(factory)
{
}