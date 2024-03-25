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

app.MapGet("/events", async (GestorNFEpagamentosXML.Db.DataContext context) =>
    {
        return await context.Eventos.ToListAsync();
    })
    .WithName("GetEvents")
    .WithOpenApi();


app.Run();