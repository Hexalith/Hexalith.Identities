namespace Hexalith.Identities.EventsWebApis.Roles.Projections;

using Hexalith.Identities.Domain.Aggregates;
using Hexalith.Identities.Events.Roles;
using Hexalith.Infrastructure.DaprRuntime.Projections;

/// <summary>
/// Handles projection updates for role disabling event.
/// </summary>
public sealed class RoleDisabledProjectionUpdateHandler(IActorProjectionFactory<Role> factory)
    : AggregateProjectionUpdateEventHandler<RoleDisabled, Role>(factory)
{
}