using System.Collections.Generic;

namespace TesteCompetenciaDDA.Domain.Entities
{
    public class TipoLancamentoFinanceiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<LancamentoFinanceiro> Lancamentos { get; set; }
    }
}