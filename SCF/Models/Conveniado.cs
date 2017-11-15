using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCF.Models
{
    public class Conveniado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }

        [Required]
        public string CPF { get; set; }
        public string RG { get; set; }

        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        //TODO: Criar entidade para Cidade com itens pre existente
        public string Cidade { get; set; }

        public string TelResidencial { get; set; }
        public string TelCelular1 { get; set; }

        public string Email { get; set; }

        //TODO: Criar entidade para Estado Civil (Solteiro e Casado)
        public string EstadoCivil { get; set; }

        public string Observacao { get; set; }

        //TODO: Criar entidade para Tipo de Conveniado (Titular e Dependente)
        public string TipoConveniado { get; set; }
    }
}