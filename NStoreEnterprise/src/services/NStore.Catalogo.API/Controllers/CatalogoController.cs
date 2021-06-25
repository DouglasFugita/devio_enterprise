﻿using Microsoft.AspNetCore.Mvc;
using NStore.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NStore.Catalogo.API.Controllers
{
    [ApiController]
    public class CatalogoController : Controller
    {
        public readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }
    }
}