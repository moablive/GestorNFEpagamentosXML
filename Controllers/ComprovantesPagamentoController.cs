using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;


namespace GestorNFEpagamentosXML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprovantesPagamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public ComprovantesPagamentoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ComprovantesPagamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprovantesPagamentoMODEL>>> GetComprovantes()
        {
            return await _context.ComprovantesPagamento.ToListAsync();
        }

        // GET: api/ComprovantesPagamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComprovantesPagamentoMODEL>> GetComprovante(int id)
        {
            var comprovante = await _context.ComprovantesPagamento.FindAsync(id);

            if (comprovante == null)
            {
                return NotFound();
            }

            return comprovante;
        }

        // POST: api/ComprovantesPagamento
        [HttpPost]
        public async Task<ActionResult<ComprovantesPagamentoMODEL>> PostComprovante(ComprovantesPagamentoMODEL comprovante)
        {
            _context.ComprovantesPagamento.Add(comprovante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComprovante), new { id = comprovante.ID }, comprovante);
        }

        // PUT: api/ComprovantesPagamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprovante(int id, ComprovantesPagamentoMODEL comprovante)
        {
            if (id != comprovante.ID)
            {
                return BadRequest();
            }

            _context.Entry(comprovante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprovanteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ComprovantesPagamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprovante(int id)
        {
            var comprovante = await _context.ComprovantesPagamento.FindAsync(id);
            if (comprovante == null)
            {
                return NotFound();
            }

            _context.ComprovantesPagamento.Remove(comprovante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprovanteExists(int id)
        {
            return _context.ComprovantesPagamento.Any(e => e.ID == id);
        }
    }
}
