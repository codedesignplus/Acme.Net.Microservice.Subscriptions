namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.CreateSubscription;

[DtoGenerator]
public record CreateSubscriptionCommand(Guid Id, Guid IdClient, Guid IdProduct, Instant StartDate, Instant EndDate) : IRequest;

public class Validator : AbstractValidator<CreateSubscriptionCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
