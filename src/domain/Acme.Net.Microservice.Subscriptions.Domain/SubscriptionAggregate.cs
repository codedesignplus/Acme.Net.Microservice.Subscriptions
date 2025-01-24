using Acme.Net.Microservice.Subscriptions.Domain.Enums;

namespace Acme.Net.Microservice.Subscriptions.Domain;

public class SubscriptionAggregate(Guid id) : AggregateRoot(id)
{
    public Guid IdClient { get; private set; }
    public Guid IdProduct { get; private set; }
    public Instant StartDate { get; private set; }
    public Instant EndDate { get; private set; }
    public SubscriptionStatus Status { get; private set; }

    private SubscriptionAggregate(Guid id, Guid idClient, Guid idProduct, Instant startDate, Instant endDate, Guid tenant, Guid createdBy) : this(id)
    {
        IdClient = idClient;
        IdProduct = idProduct;
        StartDate = startDate;
        EndDate = endDate;
        Status = SubscriptionStatus.Active;
        Tenant = tenant;
        CreatedBy = createdBy;
        CreatedAt = SystemClock.Instance.GetCurrentInstant();

        AddEvent(SubscriptionCreatedDomainEvent.Create(Id, IdClient, IdProduct, Status, StartDate, EndDate, Tenant, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt));
    }

    public static SubscriptionAggregate Create(Guid id, Guid idClient, Guid idProduct, Instant startDate, Instant endDate, Guid tenant, Guid createdBy)
    {
        DomainGuard.GuidIsEmpty(id, Errors.InvalidId);
        DomainGuard.GuidIsEmpty(idClient, Errors.InvalidIdClient);
        DomainGuard.GuidIsEmpty(idProduct, Errors.InvalidIdProduct);
        DomainGuard.GuidIsEmpty(tenant, Errors.InvalidTenant);
        DomainGuard.GuidIsEmpty(createdBy, Errors.InvalidCreatedBy);
        DomainGuard.IsTrue(startDate == Instant.MinValue, Errors.InvalidStartDate);
        DomainGuard.IsTrue(endDate == Instant.MinValue, Errors.InvalidEndDate);
        DomainGuard.IsTrue(startDate > endDate, Errors.StartDateGreaterThanEndDate);

        return new SubscriptionAggregate(id, idClient, idProduct, startDate, endDate, tenant, createdBy);
    }

    public void Update(Guid idProduct, Instant startDate, Instant endDate, Guid updatedBy)
    {
        DomainGuard.GuidIsEmpty(idProduct, Errors.InvalidIdProduct);
        DomainGuard.GuidIsEmpty(updatedBy, Errors.InvalidUpdatedBy);
        DomainGuard.IsTrue(startDate == Instant.MinValue, Errors.InvalidStartDate);
        DomainGuard.IsTrue(endDate == Instant.MinValue, Errors.InvalidEndDate);
        DomainGuard.IsTrue(startDate > endDate, Errors.StartDateGreaterThanEndDate);

        IdProduct = idProduct;
        StartDate = startDate;
        EndDate = endDate;
        UpdatedBy = updatedBy;
        UpdatedAt = SystemClock.Instance.GetCurrentInstant();

        AddEvent(SubscriptionUpdatedDomainEvent.Create(Id, IdClient, IdProduct, Status, StartDate, EndDate, Tenant, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt));
    }

    public void CancelSuscription(Guid updatedBy)
    {
        DomainGuard.GuidIsEmpty(updatedBy, Errors.InvalidUpdatedBy);

        Status = SubscriptionStatus.Canceled;
        UpdatedBy = updatedBy;
        UpdatedAt = SystemClock.Instance.GetCurrentInstant();

        AddEvent(SubscriptionCanceledDomainEvent.Create(Id, IdClient, IdProduct, Status, StartDate, EndDate, Tenant, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt));
    }

    public void InactivateSubscription(Guid updatedBy)
    {
        DomainGuard.GuidIsEmpty(updatedBy, Errors.InvalidUpdatedBy);

        Status = SubscriptionStatus.Inactive;
        UpdatedBy = updatedBy;
        UpdatedAt = SystemClock.Instance.GetCurrentInstant();

        AddEvent(SubscriptionInactivatedDomainEvent.Create(Id, IdClient, IdProduct, Status, StartDate, EndDate, Tenant, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt));
    }
}
