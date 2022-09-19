using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Api.Controllers;
using Pulsati.Core.Api.Enums;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.Autenticacao.Claims;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Services.CommandHandlers;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Services;
using Ioutility.Franquias.Domain.Franquias.ViewModels;

namespace Ioutility.Franquias.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranquiaController : EntityBasicController<Franquia, FranquiaListagemDTO, FranquiaDTO, FranquiaDTO, FranquiaDTO>
    {
        public readonly IBancoRepository _bancoRepository;
        public readonly IFranquiaRepository _repository;
        public FranquiaController(FranquiaCommandHandler commandHandler
            , IFranquiaRepository repositoryReadonly
            , IMapper mapper
            , DomainNotification domainNotification
            , UsuarioHttpRequest usuarioHttpRequest
            , IBancoRepository bancoRepository
            , bool exigeAutenticacao = false) : base(commandHandler
                , repositoryReadonly
                , mapper
                , domainNotification
                , usuarioHttpRequest
                , exigeAutenticacao)
        {
            _bancoRepository = bancoRepository;
            _repository = repositoryReadonly;
        }

        protected override string GetClaimTipoParaContrutor() => ClaimTipo.PACIENTE; //revisar com Cassiano

        protected override FranquiaDTO ConverterEntidadeDominioParaViewModel(Franquia entity)
        {
            var viewModel = base.ConverterEntidadeDominioParaViewModel(entity);
            viewModel.DadosBancarios.BancoNome = _bancoRepository.BuscarPorId(entity.DadosBancarios.BancoId)!.LabelValue;
            return viewModel;
        }

        [HttpGet("avancado")]
        public async Task<IActionResult> BuscarAvancado([FromQuery] FranquiaBuscarAvancadoViewModel query)
        {
            var fornecedores = await _repository.BuscarAvancado(query);
            return Response(fornecedores);
        }
       
        [HttpGet("{id}/status")]
        public async Task<IActionResult> FornecedorStatus(Guid id)
        {
            var franquia = await (RepositoryReadonly as IFranquiaRepository).BuscarPorIdAsync(id);
            return Response(new { id, franquia.Acesso.FranquiaStatus });
        }
        /*
        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(Guid id, FranquiaAtualizarStatusCommand command)
        {
            if (id != command.Id) return BadRequest($"o id: {id} passado na URL não é o mesmo passado na entidade: {command.Id}");
            await ((FranquiaCommandHandler)CommandHandler).HandlerAtualizarStatusAsync(command);
            return Response(null, ETipoRespostaSuccess.NoContent);
        }
        */

    }
}
