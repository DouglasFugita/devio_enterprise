using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NStore.Core.Messages.Integration
{
    public class PedidoRealizadoIntegrationEvent: IntegrationEvent
    {
        public Guid ClienteId { get; private set; }

        public PedidoRealizadoIntegrationEvent(Guid clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
