using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Services;
using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Api.Controllers;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Ioutility.Franquias.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FranquiaController : EntityBasicController<Franquia, FranquiaDTO, FranquiaDTO, FranquiaDTO, FranquiaDTO>
    {
        private readonly IFranquiaRepository _repository;
        public FranquiaController(FranquiaCommandHandler commandHandler,
            IEntityQueryRepository<Franquia> repositoryReadonly,
            IMapper mapper, DomainNotification domainNotification,
            UsuarioHttpRequest usuarioHttpRequest,
            bool exigeAutenticacao = false) : base(commandHandler, repositoryReadonly, mapper, domainNotification, usuarioHttpRequest, exigeAutenticacao)
        {
            _repository = (IFranquiaRepository)repositoryReadonly;
        }
        protected override string GetClaimTipoParaContrutor()
        {
            throw new NotImplementedException();
        }
}
}
