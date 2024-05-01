using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;


namespace GestorNFEpagamentosXML.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendedoresController : ControllerBase
{
    private readonly DataContext _context;

    public VendedoresController(DataContext context)
    {
        _context = context;
    }

    // GET: api/Vendedor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendedoresMODEL>>> GetVendedores()
    {
        return await _context.Vendedores.ToListAsync();
    }

    // GET: api/Vendedor/1
    [HttpGet("{id}")]
    public async Task<ActionResult<VendedoresMODEL>> GetVendedor(int id)
    {
        var vendedor = await _context.Vendedores.FindAsync(id);

        if (vendedor == null)
        {
            return NotFound();
        }

        return vendedor;
    }


    // DELETE: api/Vendedores/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVendedor(int id)
    {
        var vendedor = await _context.Vendedores.FindAsync(id);
        if (vendedor == null)
        {
            return NotFound();
        }

        _context.Vendedores.Remove(vendedor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
