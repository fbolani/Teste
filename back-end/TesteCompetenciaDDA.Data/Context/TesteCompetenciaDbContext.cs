using Microsoft.EntityFrameworkCore;
using TesteCompetenciaDDA.Data.Context.Mapping;

namespace TesteCompetenciaDDA.Data.Context
{
    public class TesteCompetenciaDbContext : DbContext
    {
        public TesteCompetenciaDbContext(DbContextOptions<TesteCompetenciaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            TipoLancamentoFinanceiroMapping.Map(modelBuilder);
            LancamentoFinanceiroMapping.Map(modelBuilder);
            BalancoDiaMapping.Map(modelBuilder);
        }
    }
}