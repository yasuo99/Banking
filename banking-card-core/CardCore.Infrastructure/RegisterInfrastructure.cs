using Microsoft.Extensions.DependencyInjection;

namespace CardCore.Infrastructure
{
    public static class RegisterInfrastructure
    {
        public static IServiceCollection RegistereInfrastructureService(this ServiceCollection serviceCollection){
            serviceCollection.AddDistributedMemoryCache(opt => {
                opt.TrackStatistics = false;
            });
            return serviceCollection;
        }
    }
}