using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Services.CommandHandlers;
using Pulsati.Core.Domain.Services.Validacao;

namespace Ioutility.Franquias.Domain.Franquias.Services
{
    public class FranquiaCommandHandler : EntityCommandHandler<Franquia, FranquiaDTO, FranquiaDTO>
    {
        public FranquiaCommandHandler(DomainNotification domainNotification
            , IFranquiaRepository repository
            , IMapper mapper
            , EntityValidacaoService<Franquia> validadorService
            , EventStoreService eventStoreService) : base(domainNotification, repository, mapper, validadorService, eventStoreService)
        {
        }
    }
}
