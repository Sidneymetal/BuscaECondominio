using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{   
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        public Task AlterarEmail(int id, string alterarEmail);
        public Task AlterarSenha(int id, string alterarSenha);
        public Task AlterarNome(int id, string alterarNome);
        public Task AlterarUrlImagemCadastro(int id, string alterarurlImagemCadastro);
        public Task<Usuario> LoginBuscarPorEmail(string emailDoUsuario); 
    }    
}