using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TesteCompetenciaDDA.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T Objeto);
        Task Update(T Objeto);
        Task Remove(T Objeto);
        Task<T> FindAsync(int Id);
        Task<List<T>> ToListAsync();
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task UpdateRange(List<T> Lista);
    }
}