using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Service
{
    public class AmazonService
    {        
        private readonly AmazonRekognitionClient _rekognitionClient;
        private readonly IAmazonS3 _amazonS3;        
        public readonly List<string> _imageFormats = new List<string>() { "image/jpeg", "image/png" };
        public AmazonService(IAmazonS3 amazonS3, AmazonRekognitionClient rekognitionClient)
        {         
            _amazonS3 = amazonS3;
            _rekognitionClient = rekognitionClient;
        }       
        public async Task<string> SalvarNoS3(IFormFile image)
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
        public async Task DeletarImagemNoS3(string nomeBucket, string nomeArquivo)
        {
            var response = await _amazonS3.DeleteObjectAsync("imagens-aula", nomeArquivo);
        }
    }
}        
    


