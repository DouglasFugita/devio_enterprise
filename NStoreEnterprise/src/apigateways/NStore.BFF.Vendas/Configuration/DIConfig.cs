using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NStore.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.BFF.Vendas.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

        }
    }
}
