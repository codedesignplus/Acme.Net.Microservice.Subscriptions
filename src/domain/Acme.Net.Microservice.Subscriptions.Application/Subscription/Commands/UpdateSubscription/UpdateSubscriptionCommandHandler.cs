namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.UpdateSubscription;

public class UpdateSubscriptionCommandHandler(ISubscriptionRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<UpdateSubscriptionCommand>
{
    public async Task Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var suscription = await repository.FindAsync<SubscriptionAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsNull(suscription, Errors.SuscriptionNotFound);

        suscription.Update(request.IdProduct, request.StartDate, request.EndDate, user.IdUser);

        await repository.UpdateAsync(suscription, cancellationToken);

        await pubSub.PublishAsync(suscription.GetAndClearEvents(), cancellationToken);
    }
}