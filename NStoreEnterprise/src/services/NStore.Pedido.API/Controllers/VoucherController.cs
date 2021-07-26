using Microsoft.AspNetCore.Authorization;
using NStore.WebAPI.Core.Controllers;

namespace NStore.Pedidos.API.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
    }
}
