using System;
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
        private readonly INotificacaoService NotificacaoService;
        public LancamentoService(ILancamentoFinanceiroRepository lancamentoFinanceiroRepository,
                                 INotificacaoService notificacaoService)
        {
            this.LancamentoFinanceiroRepository = lancamentoFinanceiroRepository;
            this.NotificacaoService = notificacaoService;
        }

        public async Task<List<LancamentoFinanceiro>> ListarTodosLancamentosFinanceiros()
        {
            return await this.LancamentoFinanceiroRepository.ToListAsync();
        }

        public async Task<LancamentoFinanceiro> ObterPorID(int Id)
        {
            return await this.LancamentoFinanceiroRepository.FindAsync(Id);
        }

        public async Task AdicionarLancamentoFinanceiro(LancamentoFinanceiro signature)
        {
            if (signature.IsValid(out string msg))
                await this.LancamentoFinanceiroRepository.AddAsync(signature);
            else
                NotificacaoService.AddNotificacao(msg);
        }

        public async Task AtualizarLancamentoFinanceiro(LancamentoFinanceiro signature)
        {
            LancamentoFinanceiro lancamento = await this.ObterPorID((int)signature.Id);
            if (PodeModificar(lancamento))
            {
                lancamento.SetValues(signature);
                if (lancamento.IsValid(out string msg))
                    await this.LancamentoFinanceiroRepository.Update(lancamento);
                else
                    NotificacaoService.AddNotificacao(msg);
            }
        }

        public async Task ExcluirLancamentoFinanceiro(int id)
        {
            LancamentoFinanceiro lancamento = await this.ObterPorID(id);
            if (PodeModificar(lancamento))
            {
                await this.LancamentoFinanceiroRepository.Remove(lancamento);
            }
        }

        public async Task<List<LancamentoFinanceiro>> ListarLancamentosDia(DateTime dateTime)
        {
            return await this.LancamentoFinanceiroRepository.ToListAsync(w => w.DataHora.Date == dateTime.Date);
        }

        private bool PodeModificar(LancamentoFinanceiro lancamento)
        {
            if (lancamento == null)
            {
                this.NotificacaoService.AddNotificacao("Lançamento não encontrado");
                return false;
            }
            else if (lancamento.Status)
            {
                this.NotificacaoService.AddNotificacao("Este lançamento não pode ser modificado/excluido, pois já foi conciliado");
                return false;
            }
            return true;
        }
    }
}