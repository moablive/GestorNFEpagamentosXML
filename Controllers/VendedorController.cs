﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using GestorNFEpagamentosXML.Db;
using GestorNFEpagamentosXML.Models;


namespace GestorNFEpagamentosXML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly DataContext _context;

        public VendedorController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Vendedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorMODEL>>> GetVendedores()
        {
            return await _context.Vendedores.ToListAsync();
        }

        // GET: api/Vendedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendedorMODEL>> GetVendedor(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }
    }
}