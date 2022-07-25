using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using S3Object = Amazon.Rekognition.Model.S3Object;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace BuscaECondominio.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepositorio _repositorio;
        private readonly AmazonRekognitionClient _rekognitionClient;
        private readonly IAmazonS3 _amazonS3;

        public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();
        public readonly List<string> _imageFormats = new List<string>() { "image/jpeg", "image/png" };


        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepositorio repositorio, IAmazonS3 amazonS3, AmazonRekognitionClient rekognitionClient)
        {
            _logger = logger;
            _repositorio = repositorio;
            _amazonS3 = amazonS3;
            _rekognitionClient = rekognitionClient;
        }
        [HttpGet()]
        public async Task<IActionResult> ListarUsuarios()
        {
            return Ok(await _repositorio.ListarTodos());
        }
        [HttpPost("usuario")]
        public async Task<IActionResult> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Id, usuarioDTO.Email, usuarioDTO.Cpf, usuarioDTO.DataNascimento, usuarioDTO.Nome, usuarioDTO.Senha, usuarioDTO.DataCriacao);
            await _repositorio.AdicionarUsuario(usuario);
            return Ok("Usuario adicionado.");
        }

        [HttpPost("imagem")]
        public async Task<IActionResult> CadastrarImagem(int id, IFormFile imagem)
        {
            var nomeArquivo = await SalvarNoS3(imagem);
            var imagemValida = await ValidarImagem(nomeArquivo);
            if (imagemValida)
            {
                return Ok();
            }
            else
            {
                await _amazonS3.DeleteObjectAsync("imagens-aula", nomeArquivo);
                return BadRequest();
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
        private async Task<bool> ValidarImagem(string nomeArquivo)
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


        [HttpPut()]
        public async Task<IActionResult> AlterarUsuario(int id)
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
