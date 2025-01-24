namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Queries.GetAllSubscription;

public class GetAllSubscriptionQueryHandler(ISubscriptionRepository repository, IMapper mapper, IUserContext user) : IRequestHandler<GetAllSubscriptionQuery, List<SubscriptionDto>>
{
    public async Task<List<SubscriptionDto>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
    {
         ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var suscriptions = await repository.MatchingAsync<SubscriptionAggregate>(request.Criteria, user.Tenant, cancellationToken);

        return mapper.Map<List<SubscriptionDto>>(suscriptions);
    }
}
