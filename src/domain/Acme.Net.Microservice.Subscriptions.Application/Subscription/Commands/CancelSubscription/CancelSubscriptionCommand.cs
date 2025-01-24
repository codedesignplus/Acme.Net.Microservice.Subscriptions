namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.CancelSubscription;

[DtoGenerator]
public record CancelSubscriptionCommand(Guid Id) : IRequest;

public class Validator : AbstractValidator<CancelSubscriptionCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
