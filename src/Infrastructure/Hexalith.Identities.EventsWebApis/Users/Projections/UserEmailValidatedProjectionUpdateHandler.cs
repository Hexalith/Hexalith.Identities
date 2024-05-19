namespace Hexalith.Identities.EventsWebApis.Users.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Users;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for user email validation event.
/// </summary>
public sealed class UserEmailValidatedProjectionUpdateHandler(IActorProjectionFactory<User> factory)
    : AggregateProjectionUpdateEventHandler<UserEmailValidated, User>(factory)
{
}