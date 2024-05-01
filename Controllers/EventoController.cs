//System
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dapper;

//Project
using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;

namespace GestorNFEpagamentosXML.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventMODEL>>> GetEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Evento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventMODEL>> GetEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // POST: api/Evento/Pagar/5
        [HttpPost("pagar/{id}")]
        public async Task<IActionResult> MarcarComoPago(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            evento.status_pagamento = "Pago";
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Evento/NaoPagar/5
        [HttpPost("naopagar/{id}")]
        public async Task<IActionResult> MarcarComoNaoPago(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            evento.status_pagamento = "NaoPago";
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("VendedorPorCnpj/{cnpj}/{idEvento}")]
        public async Task<ActionResult<string>> GetVendedorPorCnpj(string cnpj, int idEvento)
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
            FROM Evento e
            INNER JOIN Vendedores v ON e.CODIGO_VENDEDOR = v.CODIGO_VENDEDOR
            WHERE e.CNPJ = @Cnpj AND e.ID = @IdEvento";

            var vendedorNome = await connection.QueryFirstOrDefaultAsync<string>(
                query, 
                new { Cnpj = cnpj, IdEvento = idEvento }
            );

            await connection.CloseAsync();

            if (string.IsNullOrEmpty(vendedorNome))
            {
                return NotFound("Vendedor não encontrado para o CNPJ e ID do evento fornecidos.");
            }

            return Ok(vendedorNome);
        }

    }


