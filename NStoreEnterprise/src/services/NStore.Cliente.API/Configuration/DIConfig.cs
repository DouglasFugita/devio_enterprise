using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NStore.Clientes.API.Application.Commands;
using NStore.Clientes.API.Data;
using NStore.Clientes.API.Data.Repository;
using NStore.Clientes.API.Models;
using NStore.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Clientes.API.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();

        }
    }
}
