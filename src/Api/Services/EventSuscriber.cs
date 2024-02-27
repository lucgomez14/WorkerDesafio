using Amazon.Runtime.Internal.Util;
using Andreani.Arq.AMQStreams.Class;
using Andreani.Arq.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;
using System.Threading.Tasks;
using worker_application.Application.Common.Interfaces;

namespace worker_application.Services
{
    public class EventSuscriber: ISubscriber
    {
        private readonly IPedidoEventService _service;
        private readonly IPublisher _publisher;
        public EventSuscriber(IPedidoEventService service, IPublisher publisher)
        {
                _service = service;
                _publisher = publisher;
        }
        public async Task Consume(Pedido @event)
        {
                var message = await _service.AsignarPedido(@event);
                await _publisher.To(message, "PedidoAsignado");
        }
    }
}
