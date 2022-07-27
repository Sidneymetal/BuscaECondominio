using Amazon.Runtime;
using BuscaECondominio.Application;
using BuscaECondominio.Application.Service;
using BuscaECondominio.Lib.Data;
using BuscaECondominio.Lib.Data.Repositorios;
using BuscaECondominio.Lib.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BuscaECondominioContext>(conn => conn.UseNpgsql(builder.Configuration.GetConnectionString("BuscaECondominio")).UseSnakeCaseNamingConvention());

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); 

builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var awsOptions = builder.Configuration.GetAWSOptions();
awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();
builder.Services.AddDefaultAWSOptions(awsOptions);
