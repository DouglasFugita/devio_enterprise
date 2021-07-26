using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NStore.Clientes.API.Services;
using NStore.Core.Utils;
using NStore.MessageBus;

namespace NStore.BFF.Vendas.Configuration
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
