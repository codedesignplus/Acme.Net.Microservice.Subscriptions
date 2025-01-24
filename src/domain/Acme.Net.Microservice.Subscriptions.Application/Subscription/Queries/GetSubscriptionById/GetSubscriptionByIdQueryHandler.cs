using CodeDesignPlus.Net.Cache.Abstractions;

namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Queries.GetSubscriptionById;

public class GetSubscriptionByIdQueryHandler(ISubscriptionRepository repository, IMapper mapper, IUserContext user, ICacheManager cacheManager) : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionDto>
{
    public async Task<SubscriptionDto> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {        
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exists = await cacheManager.ExistsAsync(request.Id.ToString());

        if (exists)
            return await cacheManager.GetAsync<SubscriptionDto>(request.Id.ToString());

        var suscription = await repository.FindAsync<SubscriptionAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(suscription, Errors.SuscriptionNotFound);

        await cacheManager.SetAsync(request.Id.ToString(), mapper.Map<SubscriptionDto>(suscription));

        return mapper.Map<SubscriptionDto>(suscription);
    }
}
