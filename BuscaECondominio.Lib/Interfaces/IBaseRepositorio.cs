using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{
    public interface IBaseRepositorio<T> where T : ModelBase
    {
        public Task<List<T>> ListarTodos(); 
        public Task <T> ListarUsuarioPorId(Guid id);       
        public Task CadastrarUsuario(T item);
        public Task DeletarUsuario(Guid id);
    }
}