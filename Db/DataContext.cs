using Microsoft.EntityFrameworkCore;
using GestorNFEpagamentosXML.Models;

namespace GestorNFEpagamentosXML.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<eventMODEL> Eventos { get; set; }
    }
}