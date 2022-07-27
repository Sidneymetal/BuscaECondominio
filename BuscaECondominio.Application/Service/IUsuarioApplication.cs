using BuscaECondominio.Application.Service;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Application
{
    public interface IUsuarioApplication 
    {    
         Task<List<Usuario>> ListarUsuario();     
         Task<int> AdicionarUsuario(UsuarioDTO usuarioDTO);
         Task<bool> CadastrarImagem(int id, IFormFile imagem);         
         Task<bool> ValidarImagem(string nomeArquivo);
         Task<bool> AlterarSenha(int id, string alterarSenha);
         Task<bool> LoginPorEmailESenha(string email, string senha);
         Task<bool> ConferirSenhaDoUsuario(Usuario idUsuario, string senha);
         Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image);
         Task<bool> DeletarUsuario(int id);         
    }
}