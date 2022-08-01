using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Application.Service
{
    public class UsuarioApplication : IUsuarioApplication
    {       
        private readonly IUsuarioRepositorio _repositorio;
        private readonly AmazonRekognitionClient _rekognitionClient;
        private readonly IAmazonS3 _amazonS3;
        public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();
        public readonly List<string> _imageFormats = new List<string>() { "image/jpeg", "image/png" };


        public UsuarioApplication(IUsuarioRepositorio repositorio, IAmazonS3 amazonS3, AmazonRekognitionClient rekognitionClient)
        {            
            _repositorio = repositorio;
            _amazonS3 = amazonS3;
            _rekognitionClient = rekognitionClient;
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
            var nomeArquivo = await SalvarNoS3(imagem);
            var imagemValida = await ValidarImagem(nomeArquivo);
            if (imagemValida)
            {
                await _repositorio.AlterarUrlImagemCadastro(id, nomeArquivo);
                
            }
            else
            {
                await _amazonS3.DeleteObjectAsync("imagens-aula", nomeArquivo);
                throw new Exception("A imagem não é válida.");
            }
        }
        private async Task<string> SalvarNoS3(IFormFile image)
        {
            if (!_imageFormats.Contains(image.ContentType))
                throw new Exception("Tipo inválido.");
            using (var imageStream = new MemoryStream())
            {
                await image.CopyToAsync(imageStream);

                var request = new PutObjectRequest();
                request.Key = "reconhecimento" + image.FileName;
                request.BucketName = "imagens-aula";
                request.InputStream = imageStream;

                var response = await _amazonS3.PutObjectAsync(request);
                return request.Key;
            }
        }
        public async Task<bool> ValidarImagem(string nomeArquivo)
        {
            var entrada = new DetectFacesRequest();
            var imagem = new Image();

            var s3Object = new Amazon.Rekognition.Model.S3Object()
            {
                Bucket = "imagens-aula",
                Name = nomeArquivo
            };

            imagem.S3Object = s3Object;
            entrada.Image = imagem;
            entrada.Attributes = new List<string>() { "ALL" };

            var resposta = await _rekognitionClient.DetectFacesAsync(entrada);

            if (resposta.FaceDetails.Count() == 1 && resposta.FaceDetails[0].Eyeglasses.Value == false)
            {
                return true;
            }
            return false;
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
            var buscarUsuarioImagem = await BuscarUsuarioPorImagem(buscarUsuarioId.UrlImagemCadastro, image);
            if(buscarUsuarioImagem)
            {
                return true;
            }
            throw new Exception ("A imagem do usuário não corresponde com o cadastro.");
        }
        public async Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image)
        {
            using (var memoriaStream = new MemoryStream()) // Buscar imagem no banco de dados
            {
                var request = new CompareFacesRequest();

                var requestSource = new Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    {
                        Bucket = "imagens-aula",
                        Name = urlImagemCadastro
                    }
                };
                await image.CopyToAsync(memoriaStream);

                var requestTarget = new Image()
                {
                    Bytes = memoriaStream
                };

                request.SourceImage = requestSource;
                request.TargetImage = requestTarget;
                
                var response = await _rekognitionClient.CompareFacesAsync(request);
                if (response.FaceMatches.Count == 1 && response.FaceMatches.First().Similarity >= 90)
                {
                    return true;
                }
                return false;
            }
        }        
        public async Task DeletarUsuario(int id)
        {
            await _repositorio.DeletarUsuario(id);            
        }       
    }
}

