namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.InactivateSubscription;

public class InactivateSubscriptionCommandHandler(ISubscriptionRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<InactivateSubscriptionCommand>
{
    public async Task Handle(InactivateSubscriptionCommand request, CancellationToken cancellationToken)
    {        
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var suscription = await repository.FindAsync<SubscriptionAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(suscription, Errors.SuscriptionNotFound);

        suscription.InactivateSubscription(user.IdUser);

        await repository.UpdateAsync(suscription, cancellationToken);

        await pubSub.PublishAsync(suscription.GetAndClearEvents(), cancellationToken);
    }
}