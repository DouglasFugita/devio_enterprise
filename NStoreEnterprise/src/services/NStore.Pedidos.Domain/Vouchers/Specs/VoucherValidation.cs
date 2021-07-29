using NStore.Core.Specification.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NStore.Pedidos.Domain.Vouchers.Specs
{
    public class VoucherValidation : SpecValidator<Voucher>
    {
        public VoucherValidation()
        {
            var dataSpec = new VoucherValidadeSpecification();
            var qtdeSpec = new VoucherQuantidadeSpecification();
            var ativoSpec = new VoucherAtivoSpecification();

            Add("dataSpec", new Rule<Voucher>(dataSpec, "Este voucher esta expirado"));
            Add("qtdeSpec", new Rule<Voucher>(qtdeSpec, "Este voucher ja foi atualizado"));
            Add("ativoSpec", new Rule<Voucher>(ativoSpec, "Este voucher nao esta ativo"));
        }
    }
}
