using Acme.Net.Microservice.Subscriptions.Domain.Enums;

namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.DataTransferObjects;

public class SubscriptionDto : IDtoBase
{
    public required Guid Id { get; set; }
    public Guid IdClient { get; set; }
    public Guid IdProduct { get; set; }
    public Instant StartDate { get; set; }
    public Instant EndDate { get; set; }
    public SubscriptionStatus Status { get; set; }

}