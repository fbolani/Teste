using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Interfaces.Repository;
using TesteCompetenciaDDA.Domain.Interfaces.Services;

namespace TesteCompetenciaDDA.Domain.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoFinanceiroRepository LancamentoFinanceiroRepository;
        public LancamentoService(ILancamentoFinanceiroRepository lancamentoFinanceiroRepository)
        {
            this.LancamentoFinanceiroRepository = lancamentoFinanceiroRepository;
        }

        public async Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros()
        {
            return await this.LancamentoFinanceiroRepository.ListarTodosLancamentosFinanceiros();
        }

        public async Task<LancamentoFinanceiro> ObterPorID(int Id)
        {
            return await this.LancamentoFinanceiroRepository.ObterLancamentoFinanceiroPorID(Id);
        }

        public async Task AdicionarLancamentoFinanceiro(LancamentoFinanceiro signature)
        {
            await this.LancamentoFinanceiroRepository.AdicionarLancamentosFinanceiros(signature);
        }

        public async Task<bool> AtualizarLancamentoFinanceiro(LancamentoFinanceiro signature)
        {
            LancamentoFinanceiro lancamento = await this.ObterPorID((int)signature.Id);
            if (lancamento == null)
                return false;
            if (lancamento.Status)
                return false;

            lancamento.DataHora = signature.DataHora;
            lancamento.Tipo = signature.Tipo;
            lancamento.Valor = signature.Valor;
            lancamento.Status = signature.Status;

            await this.LancamentoFinanceiroRepository.Atualizar(lancamento);
            return true;
        }

        public async Task<bool> ExcluirLancamentoFinanceiro(int id)
        {
            LancamentoFinanceiro lancamento = await this.ObterPorID(id);
            if (lancamento == null)
                return false;
            if (lancamento.Status)
                return false;

            await this.LancamentoFinanceiroRepository.Deletar(lancamento);
            return true;
        }
    }
}