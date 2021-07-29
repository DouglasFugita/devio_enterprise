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
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(pi => pi.Pedido)
                .WithMany(p => p.PedidoItems);

            builder.ToTable("PedidoItems");
        }
    }
}
