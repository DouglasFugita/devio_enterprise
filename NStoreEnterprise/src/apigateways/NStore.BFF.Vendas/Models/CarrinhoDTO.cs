using System.Collections.Generic;

namespace NStore.BFF.Vendas.Models
{
    public class CarrinhoDTO
    {
        public decimal ValorTotal { get; set; }
        public VoucherDTO Voucher { get; set; }
        public bool VoucherUtilizado { get; set; }
        public decimal ValorDesconto { get; set; }
        public List<ItemCarrinhoDTO> Itens { get; set; } = new List<ItemCarrinhoDTO>();

    }
}
