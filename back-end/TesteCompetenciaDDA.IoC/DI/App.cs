using Microsoft.Extensions.DependencyInjection;
using TesteCompetenciaDDA.App.App;
using TesteCompetenciaDDA.App.Interfaces;

namespace TesteCompetenciaDDA.IoC.DI
{
    internal static class App
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ILancamentoApp, LancamentoApp>();           
        }
    }
}