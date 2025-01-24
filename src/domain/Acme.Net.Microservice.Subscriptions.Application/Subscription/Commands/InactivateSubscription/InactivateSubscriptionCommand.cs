namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.InactivateSubscription;

[DtoGenerator]
public record InactivateSubscriptionCommand(Guid Id) : IRequest;

public class Validator : AbstractValidator<InactivateSubscriptionCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
