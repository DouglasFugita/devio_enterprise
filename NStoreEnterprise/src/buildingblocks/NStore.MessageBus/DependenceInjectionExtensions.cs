using Microsoft.Extensions.DependencyInjection;
using System;

namespace NStore.MessageBus
{
    public static class DependenceInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException(connection);

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
