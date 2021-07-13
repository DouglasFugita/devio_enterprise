using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NStore.Clientes.API.Services;
using NStore.Core.Utils;
using NStore.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Clientes.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));

            services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
