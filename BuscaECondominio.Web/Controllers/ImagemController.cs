using Amazon.S3;
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
        private readonly List<string> _extensoesImage = new List<string>(){"image/jpeg", "image/png"};
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

        [HttpPost]
        public async Task<IActionResult> CreateImage(IFormFile image)
        {
            
            if (!_extensoesImage.Contains(image.ContentType))
                return BadRequest("Tipo Inválido");            
            return Ok();            
        } 

        [HttpPost("bucket")]
        public async Task<IActionResult> CriarBucket(string nomeBucket)
        {
            var resposta = await _amazonS3.PutBucketAsync(nomeBucket);
            return Ok(resposta);
        }    
    }
}