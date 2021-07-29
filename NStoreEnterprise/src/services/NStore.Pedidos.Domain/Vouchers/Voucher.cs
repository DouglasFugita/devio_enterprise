using NStore.Core.DomainObjects;
using NStore.Pedidos.Domain.Vouchers.Specs;
using System;

namespace NStore.Pedidos.Domain.Vouchers
{
    public class Voucher : Entity, IAggregateRoot
    {
        public string Codigo { get; protected set; }
        public decimal? Percentual { get; protected set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDesconto { get; private set; }
        public DateTime DateCriacao { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        public bool EstaValidoParaUtilizazao()
        {
            var spec = new VoucherAtivoSpecification()
                .And(new VoucherValidadeSpecification())
                .And(new VoucherQuantidadeSpecification());

            return spec.IsSatisfiedBy(this);
        }

        public void MarcarComoUtilizado()
        {
            Ativo = false;
            Utilizado = true;
            Quantidade = 0;
            DataUtilizacao = DateTime.Now;
        }

        public void DebitarQuantidade()
        {
            Quantidade -= 1;
            if (Quantidade >= 1) return;

            MarcarComoUtilizado();
        }
    }



}
