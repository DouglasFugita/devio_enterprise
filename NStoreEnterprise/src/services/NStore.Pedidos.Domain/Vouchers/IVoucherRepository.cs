using NStore.Core.DomainObjects;
using System.Threading.Tasks;

namespace NStore.Pedidos.Domain.Vouchers
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Voucher voucher);

    }
}
