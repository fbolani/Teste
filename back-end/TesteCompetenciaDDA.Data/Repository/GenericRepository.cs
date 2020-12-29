using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Data.Context;

namespace TesteCompetenciaDDA.Data.Repository
{
    public class GenericRepository<T> where T : class
    {
        protected readonly TesteCompetenciaDbContext Context;
        public GenericRepository(TesteCompetenciaDbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(T Objeto)
        {
            await Context.Set<T>().AddAsync(Objeto);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(T Objeto)
        {
            Context.Set<T>().Remove(Objeto);
            await Context.SaveChangesAsync();
        }

        public async Task<T> FindAsync(int Id)
        {
            return await Context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> ToListAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T Objeto)
        {
            Context.Set<T>().Update(Objeto);
            await Context.SaveChangesAsync();
        }

        public async Task<List<T>> ToListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().AnyAsync(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateRange(List<T> Lista)
        {
            Context.Set<T>().UpdateRange(Lista);
            await Context.SaveChangesAsync();
        }
    }
}