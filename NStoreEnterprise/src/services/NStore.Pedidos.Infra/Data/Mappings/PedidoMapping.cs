using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NStore.Pedidos.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NStore.Pedidos.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Endereco, e =>
            {
                e.Property(e => e.Logradouro)
                    .HasColumnName("Logradouro");

                e.Property(e => e.Numero)
                    .HasColumnName("Numero");

                e.Property(e => e.Complemento)
                    .HasColumnName("Complemento");

                e.Property(e => e.Bairro)
                    .HasColumnName("Bairro");

                e.Property(e => e.Cep)
                    .HasColumnName("Cep");

                e.Property(e => e.Cidade)
                    .HasColumnName("Cidade");

                e.Property(e => e.Estado)
                    .HasColumnName("Estado");
            });

            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

            builder.HasMany(p => p.PedidoItems)
                .WithOne(pi => pi.Pedido)
                .HasForeignKey(pi => pi.PedidoId);

            builder.ToTable("Pedidos");
        }
    }
}
