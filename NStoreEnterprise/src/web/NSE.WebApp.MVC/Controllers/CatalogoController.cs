﻿using Microsoft.AspNetCore.Mvc;
using NStore.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NStore.WebApp.MVC.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        // REFIT
        //private readonly ICatalogoServiceRefit _catalogoService;

        //public CatalogoController(ICatalogoServiceRefit catalogoService)
        //{
        //    _catalogoService = catalogoService;
        //}


        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _catalogoService.ObterTodos();
            return View(produtos);
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var produto = await _catalogoService.ObterPorId(id);

            return View(produto);
        }
    }
}
