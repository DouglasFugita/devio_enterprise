﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NStore.Core.Mediator;
using NStore.Pedidos.API.Application.Commands;
using NStore.Pedidos.API.Application.Queries;
using NStore.WebAPI.Core.Controllers;
using NStore.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Pedidos.API.Controllers
{
    [Authorize]
    public class PedidoController: MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController(IMediatorHandler mediator, IAspNetUser user, IPedidoQueries pedidoQueries)
        {
            _mediator = mediator;
            _user = user;
            _pedidoQueries = pedidoQueries;
        }

        [HttpPost("pedido")]
        public async Task<IActionResult> AdicionarPedido(AdicionarPedidoCommand pedido)
        {
            pedido.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediator.EnviarComando(pedido));
        }

        [HttpGet("pedido/ultimo")]
        public async Task<IActionResult> UltimoPedido()
        {
            var pedido = await _pedidoQueries.ObterUltimoPedido(_user.ObterUserId());
            return pedido == null ? NotFound() : CustomResponse(pedido);
        }

        [HttpGet("pedido/lista-cliente")]
        public async Task<IActionResult> ListaPorCliente()
        {
            var pedidos = await _pedidoQueries.ObterListaPorClienteId(_user.ObterUserId());
            return pedidos == null ? NotFound() : CustomResponse(pedidos);
        }
    }
}
