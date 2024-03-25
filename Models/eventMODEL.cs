namespace GestorNFEpagamentosXML.Models
{
    public class eventMODEL
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string NumeroNF { get; set; }
        public string RazaoSocial { get; set; }
        public DateTimeOffset DataEmissao { get; set; }
        public DateTimeOffset DataVencimento { get; set; }
        public string NomeVendedor { get; set; }
        public string TituloEvento { get; set; }
        public string Endereco { get; set; }

        public eventMODEL(int id, string cnpj, string numeroNF, string razaoSocial, DateTimeOffset dataEmissao, DateTimeOffset dataVencimento, string nomeVendedor, string tituloEvento, string endereco)
        {
            Id = id;
            CNPJ = cnpj;
            NumeroNF = numeroNF;
            RazaoSocial = razaoSocial;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            NomeVendedor = nomeVendedor;
            TituloEvento = tituloEvento;
            Endereco = endereco;
        }
    }
}