using System;
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
        Task AtualizarLancamentoFinanceiro(LancamentoFinanceiro signature);
        Task ExcluirLancamentoFinanceiro(int id);
        Task<List<LancamentoFinanceiro>> ListarLancamentosDia(DateTime dateTime);
    }
}