using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteCompetenciaDDA.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Deletar(T Objeto);
        Task<T> ObterPorID(int Id);
        Task<List<T>> ListarTodos();
    }
}