using Acme.Net.Microservice.Subscriptions.Domain.Enums;

namespace Acme.Net.Microservice.Subscriptions.Domain.DomainEvents;

[EventKey<SubscriptionAggregate>(1, "SubscriptionCanceledDomainEvent")]
public class SubscriptionCanceledDomainEvent : SubscriptionDomainBaseEvent
{
    private SubscriptionCanceledDomainEvent(
         Guid aggregateId,
         Guid? eventId = null,
         Instant? occurredAt = null,
         Dictionary<string, object>? metadata = null
    ) : base(aggregateId, eventId, occurredAt, metadata)
    {
    }

    public static SubscriptionCanceledDomainEvent Create(
        Guid aggregateId,
        Guid idClient,
        Guid idProduct,
        SubscriptionStatus status,
        Instant startDate,
        Instant endDate,
        Guid tenant,
        Guid createdBy,
        Instant createdAt,
        Guid? updatedBy,
        Instant? updatedAt
    )
    {
        return new SubscriptionCanceledDomainEvent(aggregateId)
        {
            IdClient = idClient,
            IdProduct = idProduct,
            Status = status,
            StartDate = startDate,
            EndDate = endDate,
            Tenant = tenant,
            CreatedBy = createdBy,
            CreatedAt = createdAt,
            UpdatedBy = updatedBy,
            UpdatedAt = updatedAt
        };
    }
}
