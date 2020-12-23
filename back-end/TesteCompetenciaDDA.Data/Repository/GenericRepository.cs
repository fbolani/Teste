using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Data.Context;

namespace TesteCompetenciaDDA.Data.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly TesteCompetenciaDbContext Context;
        public GenericRepository(TesteCompetenciaDbContext context)
        {
            this.Context = context;
        }

        public async Task Adicionar(T Objeto)
        {
            await Context.Set<T>().AddAsync(Objeto);
            await Context.SaveChangesAsync();
        }

        public async Task Deletar(T Objeto)
        {
            Context.Set<T>().Remove(Objeto);
            await Context.SaveChangesAsync();
        }

        public async Task<T> ObterPorID(int Id)
        {
            return await Context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> ListarTodos()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Atualizar(T Objeto)
        {
            Context.Set<T>().Update(Objeto);
            await Context.SaveChangesAsync();
        }
    }
}