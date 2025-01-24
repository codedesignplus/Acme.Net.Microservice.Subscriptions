using Acme.Net.Microservice.Subscriptions.Domain.Enums;

namespace Acme.Net.Microservice.Subscriptions.Domain.DomainEvents;

public abstract class SubscriptionDomainBaseEvent(
     Guid aggregateId,
     Guid? eventId = null,
     Instant? occurredAt = null,
     Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{

    public Guid IdClient { get; protected set; }
    public Guid IdProduct { get; protected set; }
    public SubscriptionStatus Status { get; protected set; }
    public Instant StartDate { get; protected set; }
    public Instant EndDate { get; protected set; }
    public Guid Tenant { get; protected set; }
    public Guid CreatedBy { get; protected set; }
    public Instant CreatedAt { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }
    public Instant? UpdatedAt { get; protected set; }
}
