using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros();
        Task<LancamentoFinanceiro> ObterPorID(int Id);
        Task AdicionarLancamentoFinanceiro(LancamentoFinanceiro signature);
        Task<bool> AtualizarLancamentoFinanceiro(LancamentoFinanceiro signature);
        Task<bool> ExcluirLancamentoFinanceiro(int id);
    }
}