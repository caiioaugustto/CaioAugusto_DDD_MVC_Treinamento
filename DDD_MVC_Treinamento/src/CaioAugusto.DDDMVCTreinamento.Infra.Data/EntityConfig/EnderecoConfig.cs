using CaioAugusto.DDDMVCTreinamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaioAugusto.DDDMVCTreinamento.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(a => a.Id);

            Property(c => c.Id)
                .HasColumnName("EnderecoId");

            //Caso estivesse duas PK
            //HasKey(a => new { a.ClienteId, a.CPF });

            Property(a => a.Logradouro)
                .IsRequired()
                .HasMaxLength(150);
            //Caso queira colocar o nome da coluna
            //.HasColumnName("str_Nome")

            Property(a => a.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(a => a.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(a => a.Complemento)
               .HasMaxLength(30);

            Property(a => a.Estado)
               .HasMaxLength(30);

            Property(a => a.Cidade)
               .HasMaxLength(30);

            //Relação entre Endereço e Cliente
            //Tenho um relacionamento com um cliente, onde um cliente possui muitos endereços e a FK é chamava de ClienteId
            HasRequired(a => a.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(a => a.ClienteId);

            //Nome que eu quero que minha tabela seja
            ToTable("Enderecos");

            //Caso queira definir um Schema chamado Sistemas ou qualquer outro, se for definir, no context deverá colocar a propriedade 
            //modelBuilder.HasDefaultSchema("Nome da Schema que deverá ser o mesmo que está específicado")
            //ToTable("Enderecos" , "Sistemas");
        }
    }
}
