using BuscaECondominio.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuscaECondominio.Web.Controllers 
{
    [ApiController]
    [Route("[UsuarioController]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetUsuario()
        {
            var usuario = new Usuario(1, "Sidney", "12345678901", DateTime.Parse("22/04/2089"), "mamamia@gmail.blabla", "123456", DateTime.Parse("21/04/2022"));
            return Ok(usuario);
        } 

    }
}
