using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.App.Interfaces
{
    public interface ILancamentoApp
    {
        Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros();
        Task<LancamentoFinanceiro> ObterPorID(int id);
        Task AdicionarLancamentoFinanceiro(LancamentoFinanceiro signature);
        Task<bool> AtualizarLancamentoFinanceiro(LancamentoFinanceiro signature);
        Task<bool> ExcluirLancamentoFinanceiro(int id);
    }
}