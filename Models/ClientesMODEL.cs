using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models;
    
    [Table("Clientes")]
    public class ClientesMODEL
    {
        public int? Id { get; set; }
        public int?  CODIGO_TELECON { get; set; }
        public int?  CODIGO_VENDEDOR { get; set; }
        public string?  NOME { get; set; }
        public string?  CNPJ { get; set; }
        public string?  CONTATO { get; set; }
        public string?  EMAIL { get; set; }
        public string?  PAIS { get; set; }
        public string?  ESTADO { get; set; }
        public string?  CIDADE { get; set; }
        public string?  BAIRRO { get; set; }
        public string?  RUA_AV { get; set; }
        public string?  NUMERO { get; set; }
        public string?  COMPLEMENTO { get; set; }
        public string?  CEP { get; set; }
    }
