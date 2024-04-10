//System
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Project
using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;
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
        public async Task<ActionResult<IEnumerable<ClientesMODEL>>> GetComprovantes()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
