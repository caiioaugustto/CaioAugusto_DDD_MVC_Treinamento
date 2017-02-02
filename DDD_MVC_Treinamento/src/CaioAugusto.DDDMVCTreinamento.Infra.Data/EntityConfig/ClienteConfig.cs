using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace CaioAugusto.DDDMVCTreinamento.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(a => a.Id);

            //Caso estivesse duas PK
            //HasKey(a => new { a.ClienteId, a.CPF });

            Property(c => c.Id)
                .HasColumnName("ClienteId");

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);
                //Caso queira colocar o nome da coluna
                //.HasColumnName("str_Nome")

            Property(a => a.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                //para pesquisa ser mais rápida 
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.DataNascimento)
                .IsRequired();

            Property(a => a.Ativo)
               .IsRequired();

            Property(a => a.Excluido)
               .IsRequired();

            //Nome que eu quero que minha tabela seja
            ToTable("Clientes");
        }
    }
}
