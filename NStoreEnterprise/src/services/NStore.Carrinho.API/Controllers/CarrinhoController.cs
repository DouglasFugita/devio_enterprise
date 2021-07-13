using Microsoft.AspNetCore.Authorization;
using NStore.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Carrinho.API.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
    }
}
