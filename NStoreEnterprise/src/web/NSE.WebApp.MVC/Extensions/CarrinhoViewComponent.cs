﻿using Microsoft.AspNetCore.Mvc;
using NStore.WebApp.MVC.Models;
using NStore.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.WebApp.MVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IVendasBFFService _vendasBFFService;

        public CarrinhoViewComponent(IVendasBFFService vendasBFFService)
        {
            _vendasBFFService = vendasBFFService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _vendasBFFService.ObterQuantidadeCarrinho());
        }
    }
}
