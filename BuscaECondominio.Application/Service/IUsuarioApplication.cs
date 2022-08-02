using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Application
{
    public interface IUsuarioApplication 
    {    
         Task<List<Usuario>> ListarUsuario();     
         Task <Guid>AdicionarUsuario(UsuarioDTO usuarioDTO);
         Task CadastrarImagem(int id, IFormFile imagem);        
         Task AlterarSenha(int id, string alterarSenha);
         Task<bool> LoginPorEmailESenha(string email, string senha);
         Task<bool> ConferirSenhaDoUsuario(Usuario idUsuario, string senha);
         Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image);
         Task DeletarUsuario(int id);         
    }
}