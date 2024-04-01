using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models
{
    [Table("Vendedores")]
    public class VendedorMODEL
    {
        public int? Id { get; set; }
        public string? Razao { get; set; }
        public string? CNPJ { get; set; }
        public string? vendedor { get; set; }
    }
}