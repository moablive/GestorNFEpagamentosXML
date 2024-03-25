using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models
{
    [Table("Vendedores")]
    public class Vendedor
    {
        public int Id { get; set; }
        public string Razao { get; set; }
        public string CNPJ { get; set; }
        public string vendedor { get; set; }
    }
}