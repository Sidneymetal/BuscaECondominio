using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Service;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Application.Service
{
    public class UsuarioApplication : IUsuarioApplication
    {       
        private readonly IUsuarioRepositorio _repositorio;        
        private readonly AmazonService _amazonService;
        public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();
        public readonly List<string> _imageFormats = new List<string>() { "image/jpeg", "image/png" };


        public UsuarioApplication(IUsuarioRepositorio repositorio, AmazonService amazonService)
        {            
            _repositorio = repositorio;
            _amazonService = amazonService;          
        }
        
        public async Task<List<Usuario>> ListarUsuario()
        {
            return await _repositorio.ListarTodos();
        }
        
        public async Task<int> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Id, usuarioDTO.Email, usuarioDTO.Cpf, usuarioDTO.DataNascimento, usuarioDTO.Nome, usuarioDTO.Senha, usuarioDTO.UrlImagemCadastro, usuarioDTO.DataCriacao);
            await _repositorio.AdicionarUsuario(usuario);
            return usuario.Id;
        }        
        public async Task CadastrarImagem(int id, IFormFile imagem)
        {
            
            var nomeArquivo = await _amazonService.SalvarNoS3(imagem);
            var imagemValida = await _amazonService.ValidarImagem(nomeArquivo);
            if (imagemValida)
            {
                await _repositorio.AlterarUrlImagemCadastro(id, nomeArquivo);
                
            }
            else
            {
                await _amazonService.DeletarImagemNoS3("imagens-aula", nomeArquivo);
                throw new Exception("A imagem não é válida.");
            }
        }               
        public async Task AlterarSenha(int id, string alterarSenha)
        {
            await _repositorio.AlterarSenha(id, alterarSenha);            
        }        
        public async Task<bool> LoginPorEmailESenha(string email, string senha)
        {
            var emailUsuario = await _repositorio.LoginBuscarPorEmail(email);
            var validarSenhaUsuario = await ConferirSenhaDoUsuario(emailUsuario, senha);
            if (validarSenhaUsuario)
            {
                return true;
            }
            throw new Exception("A senha do usuário está incorreta.");
        }
        public async Task<bool> ConferirSenhaDoUsuario(Usuario idUsuario, string senha)
        {
            if (idUsuario.Senha == senha)
            {
                return true;
            }
            return false;
        }        
        public async Task<bool> LoginImagem(int id, IFormFile image)
        {
            var buscarUsuarioId = await _repositorio.ListarUsuarioPorId(id);//Buscar usuário no bando por Id.
            var buscarUsuarioImagem = await _amazonService.BuscarUsuarioPorImagem(buscarUsuarioId.UrlImagemCadastro, image);
            if(buscarUsuarioImagem)
            {
                return true;
            }
            throw new Exception ("A imagem do usuário não corresponde com o cadastro.");
        }
        public async Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image)
        {           
            var buscarUsuarioImagem = await _amazonService.BuscarUsuarioPorImagem(urlImagemCadastro, image);
            if(buscarUsuarioImagem)
            {
                return true;
            }
            throw new Exception ("A imagem do usuário não corresponde com o cadastro.");             
        }        
        public async Task DeletarUsuario(int id)
        {
            await _repositorio.DeletarUsuario(id);            
        }       
    }
}

