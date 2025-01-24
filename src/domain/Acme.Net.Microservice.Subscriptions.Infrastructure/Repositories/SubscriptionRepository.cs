namespace Acme.Net.Microservice.Subscriptions.Infrastructure.Repositories;

public class SubscriptionRepository(IServiceProvider serviceProvider, IOptions<MongoOptions> mongoOptions, ILogger<SubscriptionRepository> logger) 
    : RepositoryBase(serviceProvider, mongoOptions, logger), ISubscriptionRepository
{
   
}