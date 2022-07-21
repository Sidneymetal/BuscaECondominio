using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{
    public interface IBaseRepositorio<T> where T : ModelBase
    {
        public Task<List<T>> ListarTodos(); 
        public Task <T> ListarTodosPorId(int id);       
        public Task AdicionarUsuario(T item);
        public Task DeletarUsuario(int id);
    }
}