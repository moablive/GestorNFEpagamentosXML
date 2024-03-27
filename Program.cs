using Microsoft.EntityFrameworkCore;
using GestorNFEpagamentosXML.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext do Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<GestorNFEpagamentosXML.Db.DataContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionando o servi�o de API Explorer Endpoints
builder.Services.AddEndpointsApiExplorer();

// Adicionando o servi�o de Controllers
builder.Services.AddControllers();

// Configura��o do Swagger
builder.Services.ConfigureSwaggerGen();

var app = builder.Build();

// Verifica se o ambiente
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecionamento HTTPS
app.UseHttpsRedirection();

// Mapeamento dos controladores
app.MapControllers();

// Inicia a aplica��o
app.Run();