using System;
using System.Runtime.Serialization;
using TesteCompetenciaDDA.Domain.Entities.Enums;

namespace TesteCompetenciaDDA.Domain.Entities
{
    public class LancamentoFinanceiro
    {
        public int? Id { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoFinanceiro Tipo { get; set; }
        public bool Status { get; set; }

        public void SetValues(LancamentoFinanceiro signature)
        {
            DataHora = signature.DataHora;
            Tipo = signature.Tipo;
            Valor = signature.Valor;
            Status = signature.Status;
        }

        public bool IsValid(out string result)
        {
            result = "";
            if (DataHora == DateTime.MinValue)
                result = "Data inválida.";
            else if (Valor <= 0)
                result = "Valor do lançamento deve ser maior que zero.";
            return (result == "");
        }
    }
}