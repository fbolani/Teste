using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Domain.Interfaces.Repository
{
    public interface ILancamentoFinanceiroRepository: IGenericRepository<LancamentoFinanceiro>
    {
        Task<LancamentoFinanceiro> ObterLancamentoFinanceiroPorID(int Id);
        Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros();
        Task AdicionarLancamentosFinanceiros(LancamentoFinanceiro signature);
    }
}