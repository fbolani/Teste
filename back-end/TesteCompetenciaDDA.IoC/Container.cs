using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TesteCompetenciaDDA.IoC
{
    public static class Container
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(provider => configuration);
            DI.Database.Configure(services, configuration);
            DI.Repository.Configure(services);
            DI.Service.Configure(services);
            DI.App.Configure(services);
        }
    }
}