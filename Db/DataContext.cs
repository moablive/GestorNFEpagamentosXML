using Microsoft.EntityFrameworkCore;
using GestorNFEpagamentosXML.Models;

namespace GestorNFEpagamentosXML.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EventMODEL> Eventos { get; set; }
        public DbSet<ClientesMODEL> Clientes { get; set; }
        public DbSet<VendedoresMODEL> Vendedores { get; set; }
        public DbSet<ComprovantesPagamentoMODEL> ComprovantesPagamento { get; set; }
        public DbSet<UserLoginMODEL> UserLoginMODEL { get; set; }
    }
}