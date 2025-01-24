using CodeDesignPlus.Net.Core.Abstractions.Models.Criteria;

namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Queries.GetAllSubscription;

public record GetAllSubscriptionQuery(Criteria Criteria) : IRequest<List<SubscriptionDto>>;

