using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Domain.Interfaces.Services
{
    public interface IBalancoService
    {
        Task ConcilarDia(DateTime dateTime);
        Task<List<BalancoDia>> ListarBalancos(int mes);
    }
}