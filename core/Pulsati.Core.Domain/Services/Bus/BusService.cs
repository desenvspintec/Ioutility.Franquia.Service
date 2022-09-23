using EasyNetQ;
using Pulsati.Core.Domain.Singletons.Ambiente;

namespace Pulsati.Core.Domain.Services.Bus
{
    public class BusService : IDisposable
    {
        public readonly IBus bus;

        public BusService()
        {
            bus = RabbitHutch.CreateBus("host=" + VariavelDeAmbiente.ObterInstanciaInicializada().EnderecoRabbitMq);
        }

        public void Dispose()
        {
            bus.Dispose();
        }
    }
}
