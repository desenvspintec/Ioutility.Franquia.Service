using AutoMapper;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Interfaces;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Ioutility.Franquias.Domain.Procedimentos.Services;
using Microsoft.AspNetCore.Http;
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
    public class ProcedimentoController : EntityController<Procedimento, ProcedimentoDTO, ProcedimentoDTO, ProcedimentoDTO>
    {
        private readonly IProcedimentoRepository _repository;
        public ProcedimentoController(
            ProcedimentoCommandHandler commandHandler,
            IEntityQueryRepository<Procedimento> repositoryReadonly,
            IMapper mapper, 
            DomainNotification domainNotification, 
            UsuarioHttpRequest usuarioHttpRequest, 
            bool exigeAutenticacao = false) : base(commandHandler, repositoryReadonly, mapper, domainNotification, usuarioHttpRequest, exigeAutenticacao)
        {
            _repository = (IProcedimentoRepository) repositoryReadonly;
        }

        protected override string GetClaimTipoParaContrutor() => "";


        [HttpGet]
        public async Task<IActionResult> BuscarPorNomeAsync([FromQuery] ProcedimentoListagemQuery query)
        {
            var entitys = await _repository.BuscarAvancado(query);
            return Ok(entitys);
        }

        //[HttpGet("avancado")]
        //public async Task<IActionResult> BuscarAvancado()
        //{
        //    var dentistas = await _repository.BuscarAvancado(query);
        //    return Response(dentistas);
        //}
    }
}
