using GestorNFEpagamentosXML.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<GestorNFEpagamentosXML.Db.DataContext>(options =>
    options.UseSqlServer(connectionString));

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


//CONSULTA TOTAL
app.MapGet("/evento", async (GestorNFEpagamentosXML.Db.DataContext context) =>
    {
        return await context.Eventos.ToListAsync();
    })
    .WithName("GetEvents")
    .WithOpenApi();

//CONSULTA DE VENDEDOR
app.MapGet("/vendedor", async (GestorNFEpagamentosXML.Db.DataContext context) =>
    {
        return await context.Vendedores.ToListAsync();
    })
    .WithName("GetVendedores")
    .WithOpenApi();

app.Run();