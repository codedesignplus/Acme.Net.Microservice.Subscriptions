namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Queries.GetSubscriptionById;

public record GetSubscriptionByIdQuery(Guid Id) : IRequest<SubscriptionDto>;

