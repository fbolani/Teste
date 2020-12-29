using System;

namespace TesteCompetenciaDDA.Domain.Entities
{
    public class BalancoDia
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorCredito { get; set; }
        public decimal ValorDebito { get; set; }
        public decimal ValorTotal { get; set; }
    }
}