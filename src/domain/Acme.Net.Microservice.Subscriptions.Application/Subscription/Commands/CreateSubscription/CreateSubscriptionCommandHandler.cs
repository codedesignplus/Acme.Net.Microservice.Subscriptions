namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler(ISubscriptionRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<CreateSubscriptionCommand>
{
    public async Task Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exist = await repository.ExistsAsync<SubscriptionAggregate>(request.Id, user.Tenant, cancellationToken);

        ApplicationGuard.IsTrue(exist, Errors.SuscriptionAlreadyExists);

        var suscription = SubscriptionAggregate.Create(request.Id, request.IdClient, request.IdProduct, request.StartDate, request.EndDate, user.Tenant, user.IdUser);

        await repository.CreateAsync(suscription, cancellationToken);

        await pubSub.PublishAsync(suscription.GetAndClearEvents(), cancellationToken);
    }
}
