using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NStore.Core.Mediator;
using NStore.Pedidos.API.Application.Queries;
using NStore.Pedidos.Domain.Vouchers;
using NStore.Pedidos.Infra.Data;
using NStore.Pedidos.Infra.Data.Repository;
using NStore.WebAPI.Core.Usuario;
using MediatR;
using NStore.Pedidos.API.Application.Commands;
using FluentValidation.Results;
using NStore.Pedidos.API.Application.Events;
using NStore.Pedidos.Domain.Pedidos;

namespace NStore.Pedidos.API.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            // Events
            services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            // Application
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            // Data
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
