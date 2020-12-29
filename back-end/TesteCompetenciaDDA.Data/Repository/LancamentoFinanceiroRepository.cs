using TesteCompetenciaDDA.Data.Context;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Interfaces.Repository;

namespace TesteCompetenciaDDA.Data.Repository
{
    public class LancamentoFinanceiroRepository : GenericRepository<LancamentoFinanceiro>, ILancamentoFinanceiroRepository
    {
        public LancamentoFinanceiroRepository(TesteCompetenciaDbContext context) : base(context) { }
    }
}