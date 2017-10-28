using SCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCF.BancoDados
{
    public class SCFInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SCFContext>
    {
        protected override void Seed(SCFContext context)
        {
            var conveniado = new List<Conveniado>
            {
            new Conveniado{Nome="Elias", Matricula="a13033202", CPF="105.025.446.51", RG="MG-14.351.718", DataNascimento=DateTime.Parse("1997-03-27"), DataAdmissao=DateTime.Parse("2017-03-27"), Logradouro="Rua Vereador Justo Machado de Brito",
            Numero="61", Complemento="Frente a rodoviaria", Bairro="Jardim Botanico", CEP="38720-000", Cidade="Lagoa Formosa",
            TelResidencial="34 3824 2481", TelCelular1="34 99667 8513", Email="eliasborges@unipam.edu.br",
            EstadoCivil="Solteiro", Observacao="Nenhuma", TipoConveniado="Titular"},
            };
            conveniado.ForEach(s => context.Conveniado.Add(s));
            context.SaveChanges();
            
        }
    }
}