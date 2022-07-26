
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using S3Object = Amazon.Rekognition.Model.S3Object;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using BuscaECondominio.Application;

namespace BuscaECondominio.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _application; 
        public UsuarioController(IUsuarioApplication application)
        {
            _application = application;
        }
        [HttpGet("ListarUsuario")]
        
        [HttpPost("AdicionarUsuario")]
        
        [HttpPost("CadastrarImagem")]
         
        [HttpPost("ValidarImagem")]         
        
        [HttpPost("LoginPorEmailESenha")]

        [HttpPost("ConferirSenhaDoUsuario")]

        [HttpPost("BuscarUsuarioPorImagem")]

        [HttpPut("AlterarSenha")]        
        
        [HttpDelete("DeletarUsuario")]          
    }
}

