using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Api.Enums;
using Pulsati.Core.Api.ViewModels;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Services.CommandHandlers;

namespace Pulsati.Core.Api.Controllers
{
    public abstract class EntityController<TEntity, TBuscaPorIdViewModel, TRegistrarCommand, TAtualizarCommand> : CoreController
        where TEntity : class, IEntityComDomainValidacao<TEntity>
        where TRegistrarCommand : class, IEntityDTO
        where TAtualizarCommand : class, IEntityDTO
        where TBuscaPorIdViewModel : class
    {
        protected readonly IEntityQueryRepository<TEntity> RepositoryReadonly;
        protected readonly IMapper Mapper;
        protected readonly EntityCommandHandler<TEntity, TRegistrarCommand, TAtualizarCommand> CommandHandler;
        public EntityController(EntityCommandHandler<TEntity, TRegistrarCommand, TAtualizarCommand> commandHandler
            , IEntityQueryRepository<TEntity> repositoryReadonly
            , IMapper mapper
            , DomainNotification domainNotification
            , UsuarioHttpRequest usuarioHttpRequest
            , bool exigeAutenticacao = true) : base(domainNotification, usuarioHttpRequest, exigeAutenticacao)
        {
            CommandHandler = commandHandler;
            RepositoryReadonly = repositoryReadonly;
            Mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorIdAsync(Guid id)
        { 
            if (!EstaAutorizadoLer()) return Forbid();

            var entity = await RepositoryReadonly.BuscarPorIdAsync(id);
            if (entity.EstaNulo()) return NotFound("entidade nao encontrada");      
            
            await RealizarOperacaoAoBuscarPorIdOverrider(entity!); 
            var entityVm = ConverterEntidadeDominioParaViewModel(entity!);
            
            return Response(entityVm);    
        }
        /// <summary>
        /// mapeia (utilizando automapper) uma entidade de dominio para view model
        /// </summary>
        /// <param name="entity">entidade a ser convertida</param>
        /// <returns>entidade view model</returns>
        protected virtual TBuscaPorIdViewModel ConverterEntidadeDominioParaViewModel(TEntity entity) => Mapper.Map<TBuscaPorIdViewModel>(entity);
        protected virtual Task RealizarOperacaoAoBuscarPorIdOverrider(TEntity entity) => Task.CompletedTask;
        
        [HttpPost]
        public virtual async Task<IActionResult> RegistrarAsync([FromBody] TRegistrarCommand entityVm)
        {
            if (!EstaAutorizadoRegistrar()) return Forbid();
            await CommandHandler.HandlerRegistrarAsync(entityVm);
            return Response(ObterDadosParaRetornarAposRegistrar(entityVm), ETipoRespostaSuccess.Created);
        }
        protected virtual RespostaCriarComSucesso ObterDadosParaRetornarAposRegistrar(IEntityDTO entityVm) => new(entityVm);
        
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> AtualizarAsync(Guid id, [FromBody] TAtualizarCommand entityVm)
        {
            if (!EstaAutorizadoRegistrar()) return Forbid();
            if (id != entityVm.Id) return BadRequest($"o id: {id} passado na URL não é o mesmo passado na entidade: {entityVm.Id}");

            await CommandHandler.HandlerAtualizarAsync(entityVm);
            return Response(null, ETipoRespostaSuccess.NoContent);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> InativarAsync(Guid id)
        {
            if (!EstaAutorizadoRegistrar()) return Forbid();

            await CommandHandler.HandlerInativarAsync(ObterCommandInativar(id));
            return Response(null, ETipoRespostaSuccess.NoContent);
        }

        protected virtual EntityInativarCommand ObterCommandInativar(Guid id) => new(id);
    }
}
