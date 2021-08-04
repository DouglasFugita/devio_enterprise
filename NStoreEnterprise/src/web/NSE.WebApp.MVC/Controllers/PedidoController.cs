using Microsoft.AspNetCore.Mvc;
using NStore.WebApp.MVC.Models;
using NStore.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.WebApp.MVC.Controllers
{
    public class PedidoController : MainController
    {
        private readonly IClienteService _clienteService;
        private readonly IVendasBFFService _vendasBFFService;

        public PedidoController(IClienteService clienteService,
            IVendasBFFService vendasBFFService)
        {
            _clienteService = clienteService;
            _vendasBFFService = vendasBFFService;
        }

        [HttpGet]
        [Route("endereco-de-entrega")]
        public async Task<IActionResult> EnderecoEntrega()
        {
            var carrinho = await _vendasBFFService.ObterCarrinho();
            if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

            var endereco = await _clienteService.ObterEndereco();
            var pedido = _vendasBFFService.MapearParaPedido(carrinho, endereco);

            return View(pedido);
        }

        [HttpGet]
        [Route("pagamento")]
        public async Task<IActionResult> Pagamento()
        {
            var carrinho = await _vendasBFFService.ObterCarrinho();
            if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

            var pedido = _vendasBFFService.MapearParaPedido(carrinho, null);

            return View(pedido);
        }

        [HttpPost]
        [Route("finalizar-pedido")]
        public async Task<IActionResult> FinalizarPedido(PedidoTransacaoViewModel pedidoTransacao)
        {
            if (!ModelState.IsValid) return View("Pagamento", _vendasBFFService.MapearParaPedido(
                await _vendasBFFService.ObterCarrinho(), null));

            var retorno = await _vendasBFFService.FinalizarPedido(pedidoTransacao);

            if (ResponsePossuiErros(retorno))
            {
                var carrinho = await _vendasBFFService.ObterCarrinho();
                if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

                var pedidoMap = _vendasBFFService.MapearParaPedido(carrinho, null);
                return View("Pagamento", pedidoMap);
            }

            return RedirectToAction("PedidoConcluido");
        }

        [HttpGet]
        [Route("pedido-concluido")]
        public async Task<IActionResult> PedidoConcluido()
        {
            return View("ConfirmacaoPedido", await _vendasBFFService.ObterUltimoPedido());
        }

        [HttpGet("meus-pedidos")]
        public async Task<IActionResult> MeusPedidos()
        {
            return View(await _vendasBFFService.ObterListaPorClienteId());
        }
    }
}
