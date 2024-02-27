using Andreani.Scheme.Onboarding;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using worker_application.Application.Common.Interfaces;

namespace worker_application.Infrastructure.Services
{
    public class PedidoEventService : IPedidoEventService
    {
        //private readonly ILogger _logger;
        //public PedidoEventService (ILogger logger)
        //{
        //        _logger = logger;
        //}
        public Task<Pedido> AsignarPedido(Pedido request)
        {
                var numeroPedido = new Random().Next(10000000, 99999999);
                var message = new Pedido
                {
                    id = request.id,
                    numeroDePedido = numeroPedido,
                    cicloDelPedido = request.cicloDelPedido,
                    codigoDeContratoInterno = request.codigoDeContratoInterno,
                    estadoDelPedido = "2",
                    cuentaCorriente = request.cuentaCorriente,
                    cuando = request.cuando
                };
                return Task.FromResult(message);
                //o asincronico? await message
        }
    }
}
