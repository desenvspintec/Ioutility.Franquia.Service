using AutoMapper;
using Moq;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Tests.UnidadeTests.Config.Singleton;

namespace Ioutility.Franquias.Tests.Config
{
    internal class CommandHandlerHelper
    {

        public static CommandHandlerHelper Obter()
        {

            return new CommandHandlerHelper(
                new DomainNotification(),
                new EventStoreService(new Mock<IEventStoreRepository>().Object),
                AutoMapperProfiles.ObterAutoMapper()
            );
        }
        private CommandHandlerHelper(DomainNotification domainNotification, EventStoreService eventStoreService, IMapper mapper)
        {
            DomainNotification = domainNotification;
            EventStoreService = eventStoreService;
            Mapper = mapper;
        }


        public DomainNotification DomainNotification { get; private set; }
        public EventStoreService EventStoreService { get; private set; }
        public IMapper Mapper { get; private set; }
    }
}
