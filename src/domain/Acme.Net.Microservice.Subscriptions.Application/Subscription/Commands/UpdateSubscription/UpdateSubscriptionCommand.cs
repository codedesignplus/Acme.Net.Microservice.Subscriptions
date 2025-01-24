namespace Acme.Net.Microservice.Subscriptions.Application.Subscription.Commands.UpdateSubscription;

[DtoGenerator]
public record UpdateSubscriptionCommand(Guid Id, Guid IdProduct, Instant StartDate, Instant EndDate) : IRequest;

public class Validator : AbstractValidator<UpdateSubscriptionCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
