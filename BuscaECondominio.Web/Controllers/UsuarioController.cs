
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using S3Object = Amazon.Rekognition.Model.S3Object;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using BuscaECondominio.Application;
using BuscaECondominio.Lib.Models;

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
        public async Task<IActionResult> ListarUsuarios()
        {
            var respostaList = await _application.ListarUsuario();
            return Ok(respostaList);
        }
        [HttpPost("AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            var respostaUsuario = await _application.AdicionarUsuario(usuarioDTO);
            return Ok(respostaUsuario);
        }
        [HttpPost("CadastrarImagem")]
        public async Task<IActionResult> CadastrarImagem(int id, IFormFile imagem)
        {
            await _application.CadastrarImagem(id, imagem);
            return Ok();
        }
        [HttpPost("LoginPorEmailESenha")]
        public async Task<IActionResult> LoginPorEmailESenha(string email, string senha)
        {
            var logUsuario = await _application.LoginPorEmailESenha(email, senha);
            return Ok(logUsuario);
        }
        [HttpGet("ConferirSenhaDoUsuario")]
        public async Task<IActionResult> ConferirSenhaDoUsuario(Usuario idUsuario, string senha)
        {
            var conferirSenha = await _application.ConferirSenhaDoUsuario(idUsuario, senha);
            return Ok(conferirSenha);
        }
        [HttpGet("BuscarUsuarioPorImagem")]
        public async Task<IActionResult> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image)
        {
            await _application.BuscarUsuarioPorImagem(urlImagemCadastro, image);
            return Ok();
        }
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(int id, string alterarSenha)
        {
            await _application.AlterarSenha(id, alterarSenha);
            return Ok("A sua senha foi alterada.");
        }
        [HttpDelete("DeletarUsuario")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            await _application.DeletarUsuario(id);
            return Ok("Usuario deletado.");
        }
    }
}




