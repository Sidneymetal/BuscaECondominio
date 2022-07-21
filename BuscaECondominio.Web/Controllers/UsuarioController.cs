using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using S3Object = Amazon.Rekognition.Model.S3Object;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace BuscaECondominio.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        protected readonly ILogger<UsuarioController> _logger;
        protected readonly IUsuarioRepositorio _repositorio;

        public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
        }
        [HttpGet()]
        public async Task<IActionResult> ListarUsuarios()
        {
            return Ok(await _repositorio.ListarTodos());
        }
        [HttpPost()]
        public async Task <IActionResult> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Id, usuarioDTO.Email, usuarioDTO.Cpf, usuarioDTO.DataNascimento, usuarioDTO.Nome, usuarioDTO.Senha, usuarioDTO.DataCriacao);
            await _repositorio.AdicionarUsuario(usuario);
            return Ok("Usuario adicionado.");
        }
        [HttpPut()]
        public async Task <IActionResult> AlterarUsuario(int id)
        {
            await _repositorio.AlterarUsuario(id);
            return Ok("Usuario alterado.");
        }
        [HttpDelete()]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            await _repositorio.DeletarUsuario(id);
            return Ok("Usuario removido.");
        }
    }
}
