using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models;

    [Table("Vendedores")]
    public class VendedoresMODEL
    {
        public int? Id { get; set; }
        public int? CODIGO_VENDEDOR { get; set; }
        public string? NOME { get; set; }
        public string? EMAIL { get; set; }
        public string? CONTATO { get; set; }
    }
