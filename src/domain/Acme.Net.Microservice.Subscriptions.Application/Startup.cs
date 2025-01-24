using CodeDesignPlus.Net.Core.Abstractions;
using Acme.Net.Microservice.Subscriptions.Application.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Net.Microservice.Subscriptions.Application
{
    public class Startup : IStartup
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            MapsterConfigSubscription.Configure();
        }
    }
}
