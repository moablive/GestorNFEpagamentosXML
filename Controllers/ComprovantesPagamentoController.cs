using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
