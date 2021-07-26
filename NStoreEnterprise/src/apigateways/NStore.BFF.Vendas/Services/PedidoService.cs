using Microsoft.Extensions.Options;
using NStore.BFF.Vendas.Extensions;
using NStore.BFF.Vendas.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NStore.BFF.Vendas.Services
{
    public interface IPedidoService
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);

    }
    public class PedidoService : Service, IPedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public async Task<VoucherDTO> ObterVoucherPorCodigo(string codigo)
        {
            var response = await _httpClient.GetAsync($"/voucher/{codigo}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<VoucherDTO>(response);
        }
    }
}
