using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Mvc;
using S3Object = Amazon.Rekognition.Model.S3Object;

namespace BuscaECondominio.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RekognitionController : ControllerBase
    {
        private readonly AmazonRekognitionClient _rekognitionClient;
        public RekognitionController(AmazonRekognitionClient rekogntionClient)
        {
            _rekognitionClient = rekogntionClient;
        }

        [HttpGet("rekoknition")]
        public async Task<IActionResult> AnalisarRosto(string nomeArquivo)
        {
            var entrada = new DetectFacesRequest();
            var imagem = new Image();

            var s3Object = new S3Object()
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
                return Ok(resposta);
            }
            return BadRequest();
        }

        [HttpPost("comparar")]
        public async Task<IActionResult> CompararRosto(string nomeArquivo, IFormFile fotoLogin)
        {
            using (var memoriaStream = new MemoryStream())
            {
                var request = new CompareFacesRequest();

                var requestSource = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Bucket = "imagens-aula",
                        Name = nomeArquivo
                    }
                };
                await fotoLogin.CopyToAsync(memoriaStream);

                var requestTarget = new Image()
                {
                    Bytes = memoriaStream
                };

                request.SourceImage = requestSource;
                request.TargetImage = requestTarget;

                var response = await _rekognitionClient.CompareFacesAsync(request);
                return Ok(response);
            }
        }
    }
}
