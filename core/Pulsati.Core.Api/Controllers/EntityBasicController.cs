using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Services.CommandHandlers;

namespace Pulsati.Core.Api.Controllers
{
    public abstract class EntityBasicController<TEntity, TBuscaPorNomeViewModel, TBuscaPorIdViewModel, TRegistrarCommand, TAtualizarCommand> : EntityController<TEntity, TBuscaPorIdViewModel, TRegistrarCommand, TAtualizarCommand>
         where TEntity : class, IEntityComDomainValidacao<TEntity>
         where TRegistrarCommand : class, IEntityBasicDTO
         where TAtualizarCommand : class, IEntityBasicDTO
         where TBuscaPorIdViewModel : class
         where TBuscaPorNomeViewModel : class
    {
        protected new readonly IEntityQueryRepository<TEntity> RepositoryReadonly;
        const int quantidadeLimiteResultadoParaBusca = 20;
        public EntityBasicController(EntityCommandHandler<TEntity, TRegistrarCommand, TAtualizarCommand> commandHandler
            , IEntityQueryRepository<TEntity> repositoryReadonly
            , IMapper mapper
            , DomainNotification domainNotification
            , UsuarioHttpRequest usuarioHttpRequest
            , bool exigeAutenticacao = true) : base(commandHandler, repositoryReadonly, mapper, domainNotification, usuarioHttpRequest, exigeAutenticacao)
        {
            RepositoryReadonly = repositoryReadonly;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorNomeAsync(string? nome = "", int quantidadeLimiteResultadoParaBusca = quantidadeLimiteResultadoParaBusca)
        {
            if (nome == null) nome = "";
            var entitys = await RepositoryReadonly.BuscarOtimizadoPorPalavraChaveAsync(nome, quantidadeLimiteResultadoParaBusca);
            return Ok(entitys);
        }

    }
}
