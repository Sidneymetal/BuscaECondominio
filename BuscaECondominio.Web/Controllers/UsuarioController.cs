
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
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                return await _application.ListarUsuario();
            }
            catch (System.Exception)
            {
                
                throw new Exception();
            }
        }
        
        [HttpPost("AdicionarUsuario")]
        public async Task<int> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                return await _application.AdicionarUsuario(usuarioDTO);
            }
            catch (System.Exception)
            {
                
                throw new Exception("Usuário não adicionado.");
            }
        }
        
        [HttpPost("CadastrarImagem")]
        public async Task<bool> CadastrarImagem(int id, IFormFile imagem)
        {
            try
            {
                return await _application.CadastrarImagem(id, imagem);
            }
            catch (System.Exception)
            {
                
                throw new Exception("Imagem não cadastrada.");
            }
        }
         
        [HttpPost("ValidarImagem")] 
        public async Task<bool> ValidarImagem(string nomeArquivo) 
        {
            try
            {
                return await _application.ValidarImagem(nomeArquivo);
            }
            catch (System.Exception)
            {
                
                throw new Exception("Imagem não foi validada.");
            }
        }       
        
        [HttpGet("LoginPorEmailESenha")]
        public async Task<bool> LoginPorEmailESenha(string email, string senha)
        {
            try
            {
                return await _application.LoginPorEmailESenha(email, senha);
            }
            catch (System.Exception)
            {
                
                throw new Exception("Login não efetuado.");
            }
        }

        [HttpGet("ConferirSenhaDoUsuario")]
        public async Task<bool> ConferirSenhaDoUsuario(Usuario idUsuario, string senha)
        {
            try
            {
                return await _application.ConferirSenhaDoUsuario(idUsuario, senha);
            }
            catch (System.Exception)
            {
                
                throw new Exception("Senha inválida.");
            }
        }

        [HttpGet("BuscarUsuarioPorImagem")]
        public async Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image)
        {
            try
            {
                return await _application.BuscarUsuarioPorImagem(urlImagemCadastro, image);
            }
            catch (System.Exception)
            {
                
                throw new Exception("Imagem não encontrada.");
            }
        }

        [HttpPut("AlterarSenha")]  
        public async Task<bool> AlterarSenha(int id, string alterarSenha) 
        {
            return await _application.AlterarSenha(id, alterarSenha);
        }     
        
        [HttpDelete("DeletarUsuario")]  
        public async Task<bool> DeletarUsuario(int id)
        {
            try
            {
                return await _application.DeletarUsuario(id);
            }
            catch (System.Exception)
            {
                
                throw new Exception ("Usuário não deletado.");
            }
        }       
    }
}

 
         
         
