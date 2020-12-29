using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteCompetenciaDDA.Data.Context;

namespace TesteCompetenciaDDA.IoC.DI
{
    internal static class Database
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TesteCompetenciaDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:TesteCompetenciaDDA"]));
        }
    }
}