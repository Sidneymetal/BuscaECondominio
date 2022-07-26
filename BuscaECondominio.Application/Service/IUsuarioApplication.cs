using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Application
{
    public interface IUsuarioApplication
    {
         Task CadastrarUsuario(UsuarioDTO dto);
         Task CadastrarImagemDoUsuario(int usuarioDTO, IFormFile imagem);
    }
}