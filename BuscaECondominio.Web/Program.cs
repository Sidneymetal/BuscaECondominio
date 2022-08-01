using Amazon.Rekognition;
using Amazon.S3;
using BuscaECondominio.Application.Service;
using BuscaECondominio.Web.Middleware;


var builder = WebApplication.CreateBuilder(args);

var injetarDependencia = new Independencia();
injetarDependencia.InjetarDependenciaProgram(builder);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

