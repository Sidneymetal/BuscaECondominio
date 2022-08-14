using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Lib.Interfaces
{   
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        public Task AlterarEmail(Guid id, string alterarEmail);
        public Task AlterarSenha(Guid id, string alterarSenha);
        public Task AlterarNome(Guid id, string alterarNome);
        public Task AlterarUrlImagemCadastro(Guid id, string alterarurlImagemCadastro);
        public Task<Usuario> LoginBuscarPorEmail(string emailDoUsuario); 
    }    
}