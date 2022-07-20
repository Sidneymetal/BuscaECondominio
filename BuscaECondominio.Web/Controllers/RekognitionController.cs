using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using BuscaECondominio.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using S3Object = Amazon.Rekognition.Model.S3Object;

namespace BuscaECondominio.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RekognitionController : ControllerBase
    {
        private readonly AmazonRekognitionClient _rekoginitionClient;
        public RekognitionController(AmazonRekognitionClient rekognitionClient)
        {
            _rekoginitionClient = rekognitionClient;
        }
        [HttpGet]
        public async Task<IActionResult> AnalisarRosto(string nomeArquivo)
        {
            var entrada = new DetectFacesRequest();
            var imagem = new Image();

            var s3Object = new S3Object()
            {
                Bucket = "imagem-aula", 
                Name = nomeArquivo
            };

            imagem.S3Object = s3Object;
            entrada.Image = imagem;

            var resposta = await _rekoginitionClient.DetectFacesAsync(entrada);
            return Ok(resposta);
        }
    }
}