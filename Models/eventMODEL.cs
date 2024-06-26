﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GestorNFEpagamentosXML.Models;

    [Table("Evento")]
    public class EventMODEL
    {
        public int? Id { get; set; }
        public string? Status { get; set; }
        public string? CNPJ { get; set; }
        public string? NumeroNF { get; set; }
        public string? RazaoSocial { get; set; }
        public DateTimeOffset? DataEmissao { get; set; }
        public DateTimeOffset? DataVencimento { get; set; }
        public string? TituloEvento { get; set; }
        public string? Endereco { get; set; }
        public string? status_pagamento { get; set; }
        public int? CODIGO_VENDEDOR { get; set; }   
    }
