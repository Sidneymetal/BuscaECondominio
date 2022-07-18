using BuscaECondominio.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using BuscaECondominio.Web.Controllers;
using BuscaECondominio.Lib.Data;
using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Data.Repositorios;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BuscaECondominioContext>(conn => conn.UseNpgsql(builder.Configuration.GetConnectionString("BuscaECondominio")).UseSnakeCaseNamingConvention());

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
