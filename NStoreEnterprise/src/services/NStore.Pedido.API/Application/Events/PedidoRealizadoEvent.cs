using NStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Pedidos.API.Application.Events
{
    public class PedidoRealizadoEvent : Event
    {
        public PedidoRealizadoEvent(Guid pedidoId, Guid clienteId)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }

        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        
    }
}
