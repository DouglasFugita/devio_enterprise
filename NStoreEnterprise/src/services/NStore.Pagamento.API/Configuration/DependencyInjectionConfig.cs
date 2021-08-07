using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NStore.Pagamentos.API.Data;
using NStore.Pagamentos.API.Data.Repository;
using NStore.Pagamentos.API.Facade;
using NStore.Pagamentos.API.Models;
using NStore.Pagamentos.API.Services;
using NStore.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Pagamentos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<PagamentosContext>();
        }
    }
}
