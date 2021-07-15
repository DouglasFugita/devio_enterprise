using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NStore.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NStore.BFF.Vendas.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        [HttpGet]
        [Route("vendas/carrinho")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse();
        }

        [HttpGet]
        [Route("vendas/carrinho-quantidade")]
        public async Task<IActionResult> ObterQuantidadeCarrinho()
        {
            return CustomResponse();
        }

        [HttpPost]
        [Route("vendas/carrinho/items")]
        public async Task<IActionResult> AdicionarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpPut]
        [Route("vendas/carrinho/items/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId)
        {
            return CustomResponse();
        }

        [HttpDelete]
        [Route("vendas/carrinho/items/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            return CustomResponse();
        }
    }
}
