using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCF.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SCF.BancoDados
{
    public class SCFContext : DbContext
    {
        public DbSet<Conveniado> Conveniado { get; set; }
        public DbSet<Cadastro> Cadastro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}