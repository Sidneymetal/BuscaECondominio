using Amazon.Rekognition;
using Amazon.Runtime;
using Amazon.S3;
using BuscaECondominio.Lib.Data;
using BuscaECondominio.Lib.Data.Repositorios;
using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuscaECondominio.Application.Service
{
    public class Independencia
    {
        public void InjetarDependenciaProgram(WebApplicationBuilder builder)
        {            

            builder.Services.AddDbContext<BuscaECondominioContext>(conn => conn.UseNpgsql(builder.Configuration.GetConnectionString("BuscaECondominio")).UseSnakeCaseNamingConvention());

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();

            builder.Services.AddScoped<IServiceAWS, ServiceAWS>();

           
            var awsOptions = builder.Configuration.GetAWSOptions();
            awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();
            builder.Services.AddDefaultAWSOptions(awsOptions);

            builder.Services.AddAWSService<IAmazonS3>();   

            builder.Services.AddScoped<AmazonRekognitionClient>();      

                 
        }
    }
}

