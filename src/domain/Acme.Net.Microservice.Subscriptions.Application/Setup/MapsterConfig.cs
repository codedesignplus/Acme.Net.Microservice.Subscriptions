namespace Acme.Net.Microservice.Subscriptions.Application.Setup;

public static class MapsterConfigSubscription
{
    public static void Configure() { 
         TypeAdapterConfig<SubscriptionDto, SubscriptionAggregate>
            .NewConfig()
            .TwoWays();
    }
}
