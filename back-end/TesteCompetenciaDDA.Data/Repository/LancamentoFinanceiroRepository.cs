using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Data.Context;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Interfaces.Repository;

namespace TesteCompetenciaDDA.Data.Repository
{
    public class LancamentoFinanceiroRepository : GenericRepository<LancamentoFinanceiro>, ILancamentoFinanceiroRepository
    {
        private readonly TesteCompetenciaDbContext Context;
        public LancamentoFinanceiroRepository(TesteCompetenciaDbContext context) : base(context)
        {
            this.Context = context;
        }
        public async Task<LancamentoFinanceiro> ObterLancamentoFinanceiroPorID(int Id)
        {
            return await Context.Set<LancamentoFinanceiro>().Include(i => i.Tipo).FirstOrDefaultAsync(i => i.Id == Id); ;
        }

        public async Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros()
        {
            return await Context.Set<LancamentoFinanceiro>().AsNoTracking().Include(i => i.Tipo).ToListAsync();
        }

        public async Task AdicionarLancamentosFinanceiros(LancamentoFinanceiro signature)
        {
            Context.Entry(signature.Tipo).State = EntityState.Modified;
            await Context.Set<LancamentoFinanceiro>().AddAsync(signature);
            await Context.SaveChangesAsync();
        }
    }
}