using System;

namespace TesteCompetenciaDDA.Domain.Entities
{
    public class LancamentoFinanceiro
    {
        public int? Id { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public virtual TipoLancamentoFinanceiro Tipo { get; set; }
        public bool Status { get; set; }
    }
}