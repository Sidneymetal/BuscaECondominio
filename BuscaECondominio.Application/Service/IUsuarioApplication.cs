using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Application
{
    public interface IUsuarioApplication 
    {    
         Task<List<Usuario>> ListarUsuario();     
         Task <Guid>CadastrarUsuario(UsuarioDTO usuarioDTO);
         Task CadastrarImagem(Guid id, IFormFile imagem);        
         Task AlterarSenha(Guid id, string alterarSenha);
         Task<bool> LoginPorEmailESenha(string email, string senha);
        //  Task<bool> ConferirSenhaDoUsuario(Usuario idUsuario, string senha);
         Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image);
         Task DeletarUsuario(Guid id);         
    }
}