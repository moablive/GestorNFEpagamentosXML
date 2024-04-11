//System
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Project
using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;
using Dapper;
namespace GestorNFEpagamentosXML.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly DataContext _context;

    public ClientesController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientesMODEL>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("VendedorPorCnpj/{cnpj}")]
    public async Task<ActionResult<string>> GetVendedorNomePorCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
        {
            return BadRequest("O CNPJ fornecido é inválido.");
        }

            // Usando a conexão existente do Entity Framework Core
            var connection = _context.Database.GetDbConnection();

            await connection.OpenAsync();

            var query = @"
            SELECT v.NOME
            FROM Vendedores v
            JOIN Clientes c ON v.CODIGO_VENDEDOR = c.CODIGO_VENDEDOR
            WHERE c.CNPJ = @Cnpj";

            var vendedorNome = await connection.QueryFirstOrDefaultAsync<string>(
                query, 
                new { Cnpj = cnpj }
            );

            await connection.CloseAsync();

            if (string.IsNullOrEmpty(vendedorNome))
            {
                return NotFound("Vendedor não encontrado para o CNPJ e ID do evento fornecidos.");
            }

            return Ok(vendedorNome);
    }

}
