using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BuscaECondominio.Web.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class  UsuarioController : ControllerBase
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
        public IActionResult ListarUsuarios(int id)
        {
            return Ok(_repositorio.ListarTodos());
        }        
        [HttpPost()]
        public IActionResult AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Id, usuarioDTO.Email, usuarioDTO.Cpf, usuarioDTO.DataNascimento, usuarioDTO.Nome, usuarioDTO.Senha, usuarioDTO.DataCriacao);
            _repositorio.AdicionarUsuario(usuario);
            return Ok("Usuario adicionado.");
        }
        [HttpPut()]
        public IActionResult AlterarUsuario(int id)
        {
            _repositorio.AlterarUsuario(id);
            return Ok("Usuario alterado.");
        }
        [HttpDelete()]
        public IActionResult DeletarUsuario(int id)
        {
            _repositorio.DeletarUsuario(id);
            return Ok("Usuario removido.");
        }    
    }
}
