using Microsoft.EntityFrameworkCore;
using GestorNFEpagamentosXML.Models;

namespace GestorNFEpagamentosXML.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EventMODEL> Eventos { get; set; }
        public DbSet<VendedorMODEL> Vendedores { get; set; }
    }
}