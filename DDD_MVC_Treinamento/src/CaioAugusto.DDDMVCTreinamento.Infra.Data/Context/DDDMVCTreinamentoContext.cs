using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaioAugusto.DDDMVCTreinamento.Infra.Data.Context
{
    public class DDDMVCTreinamentoContext : DbContext
    {
        public DDDMVCTreinamentoContext()
            : base("CaioAugustoTreinamentoContext")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");

            modelBuilder.Properties()
                .Where(a => a.Name == a.ReflectedType.Name + "Id")
                .Configure(a => a.IsKey());

            modelBuilder.Properties<string>()
                .Configure(a => a.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(a => a.HasMaxLength(100));

            base.OnModelCreating(modelBuilder);
        }
    }
}
