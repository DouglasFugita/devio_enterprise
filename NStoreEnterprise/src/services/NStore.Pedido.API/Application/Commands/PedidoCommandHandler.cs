using FluentValidation.Results;
using MediatR;
using NStore.Core.Messages;
using NStore.Pedidos.API.Application.DTO;
using NStore.Pedidos.API.Application.Events;
using NStore.Pedidos.Domain.Pedidos;
using NStore.Pedidos.Domain.Vouchers;
using NStore.Pedidos.Domain.Vouchers.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NStore.Pedidos.API.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler, IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IVoucherRepository voucherRepository, IPedidoRepository pedidoRepository)
        {
            _voucherRepository = voucherRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
        {
            // Validacao do comando
            if (!message.EhValido()) return message.ValidationResult;

            // Mapear Pedido
            var pedido = MapearPedido(message);

            // Aplicar voucher se houver
            if (!await AplicarVoucher(message, pedido)) return ValidationResult;

            // Validar pedido
            if (!ValidarPedido(pedido)) return ValidationResult;

            // Processar pagamento
            if (!ProcessarPagamento(pedido)) return ValidationResult;

            // Se pagamento tudo OK
            pedido.AutorizarPedido();

            // Adicionar evento
            pedido.AdicionarEvento(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

            // Adicionar pedido repositorio
            _pedidoRepository.Adicionar(pedido);

            // Persistir dados de pedido e voucher
            return await PersistirDados(_pedidoRepository.UnitOfWork);
        }

        private Pedido MapearPedido(AdicionarPedidoCommand message)
        {
            var endereco = new Endereco
            {
                Logradouro = message.Endereco.Logradouro,
                Numero = message.Endereco.Numero,
                Complemento = message.Endereco.Complemento,
                Bairro = message.Endereco.Bairro,
                Cep = message.Endereco.Cep,
                Cidade = message.Endereco.Cidade,
                Estado = message.Endereco.Estado
            };

            var pedido = new Pedido(
                message.ClienteId,
                message.ValorTotal,
                message.PedidoItems.Select(PedidoItemDTO.ParaPedidoItem).ToList(),
                message.VoucherUtilizado,
                message.Desconto);

            pedido.AtribuirEndereco(endereco);

            return pedido;
        }

        private async Task<bool> AplicarVoucher(AdicionarPedidoCommand message, Pedido pedido)
        {
            if (!message.VoucherUtilizado) return true;

            var voucher = await _voucherRepository.ObterVoucherPorCodigo(message.VoucherCodigo);
            if(voucher == null)
            {
                AdicionarErro("O voucher informado nao existe");
                return false;
            }

            var voucherValidation = new VoucherValidation().Validate(voucher);
            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ToList().ForEach(m => AdicionarErro(m.ErrorMessage));
                return false;
            }

            pedido.AtribuirVoucher(voucher);
            voucher.DebitarQuantidade();

            _voucherRepository.Atualizar(voucher);

            return true;
        }

        private bool ValidarPedido(Pedido pedido)
        {
            var pedidoValorOriginal = pedido.ValorTotal;
            var pedidoDesconto = pedido.Desconto;

            pedido.CalcularValorPedido();

            if(pedido.ValorTotal != pedidoValorOriginal)
            {
                AdicionarErro("O valor total do pedido nao confere com o calculo do pedido");
                return false;
            }

            if(pedido.Desconto != pedidoDesconto)
            {
                AdicionarErro("O valor total nao confere com o calculo do pedido");
                return false;
            }

            return true;
        }

        private bool ProcessarPagamento(Pedido pedido)
        {
            return true;
        }
    }
}
