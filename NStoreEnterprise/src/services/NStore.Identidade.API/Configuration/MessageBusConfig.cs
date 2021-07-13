using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NStore.Core.Utils;
using NStore.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Identidade.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
