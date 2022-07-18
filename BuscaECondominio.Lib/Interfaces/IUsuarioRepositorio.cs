using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{   
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        void AlterarUsuario(int id);
    }    
}