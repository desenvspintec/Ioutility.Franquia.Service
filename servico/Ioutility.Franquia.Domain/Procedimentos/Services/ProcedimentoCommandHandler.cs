using AutoMapper;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Interfaces;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Services.CommandHandlers;
using Pulsati.Core.Domain.Services.Validacao;

namespace Ioutility.Franquias.Domain.Procedimentos.Services
{
    public class ProcedimentoCommandHandler : EntityCommandHandler<Procedimento, ProcedimentoDTO, ProcedimentoDTO>
    {
        public ProcedimentoCommandHandler(DomainNotification domainNotification, IProcedimentoRepository repository, IMapper mapper, EntityValidacaoService<Procedimento> validadorService, EventStoreService eventStoreService) : base(domainNotification, repository, mapper, validadorService, eventStoreService)
        {
        }
    }
}
