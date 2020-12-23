using Microsoft.Extensions.DependencyInjection;
using TesteCompetenciaDDA.Data.Repository;
using TesteCompetenciaDDA.Domain.Interfaces.Repository;

namespace TesteCompetenciaDDA.IoC.DI
{
    internal static class Repository
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ILancamentoFinanceiroRepository, LancamentoFinanceiroRepository>();           
        }
    }
}