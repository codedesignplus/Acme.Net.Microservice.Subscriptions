using Acme.Net.Microservice.Subscriptions.Domain.Enums;

namespace Acme.Net.Microservice.Subscriptions.Domain.DomainEvents;

[EventKey<SubscriptionAggregate>(1, "SubscriptionUpdatedDomainEvent")]
public class SubscriptionUpdatedDomainEvent : SubscriptionDomainBaseEvent
{
    private SubscriptionUpdatedDomainEvent(
         Guid aggregateId,
         Guid? eventId = null,
         Instant? occurredAt = null,
         Dictionary<string, object>? metadata = null
    ) : base(aggregateId, eventId, occurredAt, metadata)
    {
    }

    public static SubscriptionUpdatedDomainEvent Create(
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
        return new SubscriptionUpdatedDomainEvent(aggregateId)
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