using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{   
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        public Task AlterarEmail(int id, string emailCadastrar);
    }    
}