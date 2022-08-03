using Microsoft.AspNetCore.Http;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace BuscaECondominio.Service 
{
    public interface IServiceAWS
    {
        Task<string> SalvarNoS3(IFormFile image);
        Task<bool> ValidarImagem(string nomeArquivo);
        Task<bool> BuscarUsuarioPorImagem(string urlImagemCadastro, IFormFile image);
        Task DeletarImagemNoS3(string nomeBucket, string nomeArquivo);
    }
}