using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models
{
    [Table("ComprovantesPagamento")]
    public class ComprovantesPagamentoMODEL
    {
        public int ID { get; set; }
        public string NomeArquivo { get; set; }
        public byte[] ArquivoPDF { get; set; }
    }
}
