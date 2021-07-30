using Microsoft.AspNetCore.Mvc;
using NStore.Clientes.API.Application.Commands;
using NStore.Clientes.API.Models;
using NStore.Core.Mediator;
using NStore.WebAPI.Core.Controllers;
using NStore.WebAPI.Core.Usuario;
using System;
using System.Threading.Tasks;

namespace NStore.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClientesController(IMediatorHandler mediator, IClienteRepository clienteRepository, IAspNetUser user)
        {
            _mediator = mediator;
            _clienteRepository = clienteRepository;
            _user = user;
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediator.EnviarComando(endereco));
        }
    }
}
