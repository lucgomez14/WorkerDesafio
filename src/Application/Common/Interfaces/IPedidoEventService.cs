using Andreani.Scheme.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worker_application.Application.Common.Interfaces
{
    public interface IPedidoEventService
    {
        public Task<Pedido> AsignarPedido(Pedido pedido);
    }
}
