using BuscaECondominio.Lib.Data;
using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.Rekognition;
using BuscaECondominio.Web.Middleware;
using BuscaECondominio.Application;
using BuscaECondominio.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BuscaECondominioContext>(conn => conn.UseNpgsql(builder.Configuration.GetConnectionString("BuscaECondominio")).UseSnakeCaseNamingConvention());

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var awsOptions = builder.Configuration.GetAWSOptions();
awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();
builder.Services.AddDefaultAWSOptions(awsOptions);

builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddScoped<AmazonRekognitionClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<Middleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
