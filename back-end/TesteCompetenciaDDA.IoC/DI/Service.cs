using Microsoft.Extensions.DependencyInjection;
using TesteCompetenciaDDA.Domain.Interfaces.Services;
using TesteCompetenciaDDA.Domain.Services;

namespace TesteCompetenciaDDA.IoC.DI
{
    internal static class Service
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ILancamentoService, LancamentoService>();           
        }
    }
}