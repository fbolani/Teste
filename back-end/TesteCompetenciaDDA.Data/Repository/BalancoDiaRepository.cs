using System;
using System.Collections.Generic;
using System.Text;
using TesteCompetenciaDDA.Data.Context;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Interfaces.Repository;

namespace TesteCompetenciaDDA.Data.Repository
{
    public class BalancoDiaRepository : GenericRepository<BalancoDia>, IBalancoDiaRepository
    {
        public BalancoDiaRepository(TesteCompetenciaDbContext context) : base(context)
        {

        }
    }
}
