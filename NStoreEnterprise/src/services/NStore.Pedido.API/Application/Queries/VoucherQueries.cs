using NStore.Pedidos.API.Application.DTO;
using NStore.Pedidos.Domain.Vouchers;
using System.Threading.Tasks;

namespace NStore.Pedidos.API.Application.Queries
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
    public class VoucherQueries : IVoucherQueries
    {
        private readonly IVoucherRepository _repository;

        public VoucherQueries(IVoucherRepository repository)
        {
            _repository = repository;
        }

        public async Task<VoucherDTO> ObterVoucherPorCodigo(string codigo)
        {
            var voucher = await _repository.ObterVoucherPorCodigo(codigo);

            if (voucher == null) return null;

            if (!voucher.EstaValidoParaUtilizazao()) return null;

            return new VoucherDTO
            {
                Codigo = voucher.Codigo,
                TipoDesconto = (int)voucher.TipoDesconto,
                Percentual = voucher.Percentual,
                ValorDesconto = voucher.ValorDesconto
            };
        }


    }
}
