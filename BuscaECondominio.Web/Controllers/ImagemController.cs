using Amazon.S3;
using Amazon.S3.Model;
using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BuscaECondominio.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagemController : ControllerBase
    {
        private readonly List<string> _imageFormats = new List<string>() { "image/jpeg", "image/png"};
        private readonly IAmazonS3 _amazonS3;
        public ImagemController(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }
        
        [HttpGet("bucket")]
        public async Task<IActionResult> ListarBucket()
        {
            var resposta = await _amazonS3.ListBucketsAsync();
            return Ok(resposta.Buckets.Select(x => x.BucketName));
        }        

        [HttpPost()]
        public async Task<IActionResult> CriarImagem(IFormFile image)
        {
            if (!_imageFormats.Contains(image.ContentType))
                return BadRequest("Tipo inválido");
            using (var imageStream = new MemoryStream())
            {
                await image.CopyToAsync(imageStream);

                var request = new PutObjectRequest();
                request.Key = "reconhecimento" + image.FileName;
                request.BucketName = "imagens-aula";
                request.InputStream = imageStream;

                var response = await _amazonS3.PutObjectAsync(request);
                return Ok(response);
            }
        }
        [HttpPost("bucket")]
        public async Task<IActionResult> CriarBucket(string nomeBucket)
        {
            var resposta = await _amazonS3.PutBucketAsync(nomeBucket);
            return Ok(resposta);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeletarImagem(string nameImageInS3)
        {
            var response = await _amazonS3.DeleteObjectAsync("imagens-aula", nameImageInS3);
            return Ok(response);
        }
    }
}