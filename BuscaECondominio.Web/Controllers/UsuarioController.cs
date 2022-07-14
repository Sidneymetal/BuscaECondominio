using BuscaECondominio.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuscaECondominio.Web.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public Usuario UsuarioMain { get; set; }
        [HttpGet]
        public IActionResult GetUsuario() 
        {
            var usuario = new Usuario(1, "Sidney", "12345678901", DateTime.Parse("22/04/2089"), "mamamia@gmail.blabla", "123456", DateTime.Parse("21/04/2022"));
            return Ok(usuario);
        } 
        [HttpPost]
        public IActionResult SetUsuario(Usuario usuario) 
        {
            UsuarioMain = usuario;
            return Ok(UsuarioMain);
        } 
        [HttpUpdate]

        //int id, string nome, string cpf, DateTime dataNascimento, string email, string senha, DateTime dataCadastro

    }
}
