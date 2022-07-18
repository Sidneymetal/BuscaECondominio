using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{
    public interface IBaseRepositorio<T> where T : ModelBase
    {
        List<T> ListarTodos();        
        void AdicionarUsuario(T item);
        void DeletarUsuario(int id);
    }
}