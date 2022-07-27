using Amazon.Runtime;
using BuscaECondominio.Lib.Data;
using BuscaECondominio.Lib.Data.Repositorios;
using BuscaECondominio.Lib.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuscaECondominio.Application.Service
{
    public static class Independencia
    {
        private static string[] args;

        public static void InjecaoDeIndependencia(this IServiceCollection collection, IConfiguration configuration)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BuscaECondominioContext>(conn => conn.UseNpgsql(builder.Configuration.GetConnectionString("BuscaECondominio")).UseSnakeCaseNamingConvention());

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();

            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            var awsOptions = builder.Configuration.GetAWSOptions();
            awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();
            builder.Services.AddDefaultAWSOptions(awsOptions);
        }
    }
}