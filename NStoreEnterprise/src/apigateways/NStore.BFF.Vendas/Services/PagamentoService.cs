using Microsoft.Extensions.Options;
using NStore.BFF.Vendas.Extensions;
using System;
using System.Net.Http;

namespace NStore.BFF.Vendas.Services
{
    public interface IPagamentoService
    {

    }
    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }
    }
}
