using AutoMapper;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Api.Controllers;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Services.CommandHandlers;

namespace Ioutility.Franquias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProcedimentoController : EntityBasicController<TipoProcedimento, EntityBasicDTO, TipoProcedimentoDTO, TipoProcedimentoDTO, TipoProcedimentoDTO>
    {
        public TipoProcedimentoController(EntityCommandHandler<TipoProcedimento, TipoProcedimentoDTO, TipoProcedimentoDTO> commandHandler, IEntityQueryRepository<TipoProcedimento> repositoryReadonly, IMapper mapper, DomainNotification domainNotification, UsuarioHttpRequest usuarioHttpRequest, bool exigeAutenticacao = false) : base(commandHandler, repositoryReadonly, mapper, domainNotification, usuarioHttpRequest, exigeAutenticacao)
        {
        }

        protected override string GetClaimTipoParaContrutor() => "";

    }
}
