using System.Collections.Generic;

namespace TesteCompetenciaDDA.Domain.Entities
{
    public class TipoLancamentoFinanceiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<LancamentoFinanceiro> Lancamentos { get; set; }
    }
}