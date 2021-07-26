using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NStore.WebApp.MVC.Models;
using NStore.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NStore.WebApp.MVC.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly IVendasBFFService _comprasBFFService;

        public CarrinhoController(IVendasBFFService comprasBFFService)
        {
            _comprasBFFService = comprasBFFService;
        }

        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _comprasBFFService.ObterCarrinho());
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoViewModel itemCarrinho)
        {
            var resposta = await _comprasBFFService.AdicionarItemCarrinho(itemCarrinho);
            if (ResponsePossuiErros(resposta))
                return View("Index", await _comprasBFFService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            var item = new ItemCarrinhoViewModel
            {
                ProdutoId = produtoId,
                Quantidade = quantidade
            };

            var resposta = await _comprasBFFService.AtualizarItemCarrinho(produtoId, item);

            if (ResponsePossuiErros(resposta))
                return View("Index", await _comprasBFFService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var resposta = await _comprasBFFService.RemoverItemCarrinho(produtoId);
            if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBFFService.ObterCarrinho());
            return RedirectToAction("Index");
        }

        private void ValidarItemCarrinho(ProdutoViewModel produto, int quantidade)
        {
            if (produto == null) AdicionarErroValidacao("Produto inexistente!");
            if (quantidade < 1) AdicionarErroValidacao($"Escolha ao menos uma unidade do produto {produto.Nome}");
            if (quantidade > produto.QuantidadeEstoque) AdicionarErroValidacao($"O produto {produto.Nome} possui {produto.QuantidadeEstoque} unidades em estoque. Voce selecionou {quantidade}");
        }

    }
}
