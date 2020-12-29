using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Entities.Enums;
using TesteCompetenciaDDA.Domain.Interfaces.Repository;
using TesteCompetenciaDDA.Domain.Interfaces.Services;

namespace TesteCompetenciaDDA.Domain.Services
{
    public class BalancoService : IBalancoService
    {
        private readonly ILancamentoFinanceiroRepository LancamentoFinanceiroRepository;
        private readonly IBalancoDiaRepository BalancoDiaRepository;
        private readonly INotificacaoService NotificacaoService;
        private readonly ILancamentoService LancamentoService;

        public BalancoService(ILancamentoFinanceiroRepository lancamentoFinanceiroRepository, INotificacaoService notificacaoService,
            IBalancoDiaRepository balancoDiaRepository, ILancamentoService lancamentoService)
        {
            this.LancamentoFinanceiroRepository = lancamentoFinanceiroRepository;
            this.NotificacaoService = notificacaoService;
            this.BalancoDiaRepository = balancoDiaRepository;
            this.LancamentoService = lancamentoService;
        }

        public async Task ConcilarDia(DateTime dateTime)
        {
            List<LancamentoFinanceiro> lancamentos = await this.LancamentoService.ListarLancamentosDia(dateTime);
            if (lancamentos == null || lancamentos?.Count <= 0)
            {
                this.NotificacaoService.AddNotificacao("Não há lancamentos para conciliar");
                return;
            }

            if (await this.BalancoDiaRepository.AnyAsync(w => w.Data.Date == dateTime.Date))
            {
                BalancoDia balancoDia = await this.BalancoDiaRepository.FirstOrDefaultAsync(w => w.Data.Date == dateTime.Date);
                balancoDia.ValorCredito = Math.Round(lancamentos.Where(w => w.Tipo == TipoLancamentoFinanceiro.Credito).Sum(x => x.Valor), 2);
                balancoDia.ValorDebito = Math.Round(lancamentos.Where(w => w.Tipo == TipoLancamentoFinanceiro.Debito).Sum(x => x.Valor), 2);
                balancoDia.ValorTotal = Math.Round(balancoDia.ValorCredito + (balancoDia.ValorDebito *- 1), 2);
                await this.BalancoDiaRepository.Update(balancoDia);
            }
            else
            {
                BalancoDia balancoDia = new BalancoDia
                {
                    Data = dateTime,
                    ValorCredito = Math.Round(lancamentos.Where(w => w.Tipo == TipoLancamentoFinanceiro.Credito).Sum(x => x.Valor), 2),
                    ValorDebito = Math.Round(lancamentos.Where(w => w.Tipo == TipoLancamentoFinanceiro.Debito).Sum(x => x.Valor), 2),
                };
                balancoDia.ValorTotal = Math.Round(balancoDia.ValorCredito + (balancoDia.ValorDebito *- 1), 2);
                await this.BalancoDiaRepository.AddAsync(balancoDia);
            }

            lancamentos.ForEach(f => f.Status = true);
            await this.LancamentoFinanceiroRepository.UpdateRange(lancamentos);
        }

        public async Task<List<BalancoDia>> ListarBalancos(int mes)
        {
            return (await this.BalancoDiaRepository.ToListAsync(w => w.Data.Month == mes)).OrderBy(d => d.Data).ToList();
        }
    }
}