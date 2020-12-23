using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.App.Interfaces;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Interfaces.Services;

namespace TesteCompetenciaDDA.App.App
{
    public class LancamentoApp : ILancamentoApp
    {
        private readonly ILancamentoService LancamentoService;
        public LancamentoApp(ILancamentoService lancamentoService)
        {
            this.LancamentoService = lancamentoService;
        }

        public Task AdicionarLancamentoFinanceiro(LancamentoFinanceiro signature)
        {
            return this.LancamentoService.AdicionarLancamentoFinanceiro(signature);
        }

        public async Task<bool> AtualizarLancamentoFinanceiro(LancamentoFinanceiro signature)
        {
            return await this.LancamentoService.AtualizarLancamentoFinanceiro(signature);
        }

        public async Task<bool> ExcluirLancamentoFinanceiro(int id)
        {
            return await this.LancamentoService.ExcluirLancamentoFinanceiro(id);
        }

        public async Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros()
        {
            return await this.LancamentoService.ListarTodosLancamentosFinanceiros();
        }

        public async Task<LancamentoFinanceiro> ObterPorID(int id)
        {
            return await this.LancamentoService.ObterPorID(id);
        }
    }
}