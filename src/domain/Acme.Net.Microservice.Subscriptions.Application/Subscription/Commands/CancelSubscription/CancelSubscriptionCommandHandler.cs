namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.CancelSubscription;

public class CancelSubscriptionCommandHandler(ISubscriptionRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<CancelSubscriptionCommand>
{
    public async Task Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var suscription = await repository.FindAsync<SubscriptionAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(suscription, Errors.SuscriptionNotFound);

        suscription.CancelSuscription(user.IdUser);

        await repository.UpdateAsync(suscription, cancellationToken);

        await pubSub.PublishAsync(suscription.GetAndClearEvents(), cancellationToken);
    }
}