using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCF.Models
{
    public class ContasReceber
    {
        public int ContasReceberId { get; set; }
        public int Desdobramento { get; set; } 
        public int ConveniadoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set;}
        public decimal ValorPago { get; set;}
        public DateTime DataPagamento { get; set; }
        public int Juros { get; set; }
        public decimal Desconto { get; set; }

        //1 - Aberto 2 - Fechado
        public int SituacaoContasReceber { get; set; }

    }
}