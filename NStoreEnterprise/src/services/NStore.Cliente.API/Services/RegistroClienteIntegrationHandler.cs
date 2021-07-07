using EasyNetQ;
using Microsoft.Extensions.Hosting;
using NStore.Clientes.API.Application.Commands;
using NStore.Core.Messages.Integration;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using NStore.Core.Mediator;
using FluentValidation.Results;

namespace NStore.Clientes.API.Services
{
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // TODO RabbitMQ - Utilizar AMQP
            _bus = RabbitHutch.CreateBus("host=localhost;virtualHost=EnterpriseLog;username=logUser;password=logPwd");

            _bus.Rpc.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await RegistrarCliente(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(clienteCommand);
            }

            return sucesso;


        }
    }
}
