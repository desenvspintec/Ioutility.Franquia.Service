using AutoMapper;
using Pulsati.Core.Domain.Delegates;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Services.Validacao;

namespace Pulsati.Core.Domain.Services.CommandHandlers
{
    public class EntityCommandHandler<TEntity, TRegistrarCommand, TAtualizarCommand>
        where TEntity : class, IEntityComDomainValidacao<TEntity>
        where TRegistrarCommand : class, IEntityDTO
        where TAtualizarCommand : class, IEntityDTO
    {
        protected readonly DomainNotification DomainNotification;
        protected readonly IEntityRepository<TEntity> Repository;
        protected readonly IMapper Mapper;
        protected readonly EntityValidacaoService<TEntity> ValidadorService;
        protected readonly EventStoreService EventStoreService;
        protected readonly CommandHandlerHelper<TEntity, TRegistrarCommand, TAtualizarCommand> CommandHandlerHelper;
        public CommandHandlerDelegate<TEntity, TRegistrarCommand, TAtualizarCommand> CommandHandlerDelegate { get; private set; }

        public EntityCommandHandler(DomainNotification domainNotification
           , IEntityRepository<TEntity> repository
           , IMapper mapper
           , EntityValidacaoService<TEntity> validadorService
           , EventStoreService eventStoreService)
        {
            DomainNotification = domainNotification;
            Repository = repository;
            Mapper = mapper;
            ValidadorService = validadorService;
            EventStoreService = eventStoreService;
            CommandHandlerDelegate = new CommandHandlerDelegate<TEntity, TRegistrarCommand, TAtualizarCommand>();
            CommandHandlerHelper = new CommandHandlerHelper<TEntity, TRegistrarCommand, TAtualizarCommand>(mapper
                , eventStoreService
                , CommandHandlerDelegate);

        }

        public async Task HandlerRegistrarAsync(TRegistrarCommand command)
        {
            if (command == null)
                ExceptionHelper.LancarErroException("o comando nao pode ser nulo");

            var entityPossuiIdPreenchido = command.Id != Guid.Empty;
            if (entityPossuiIdPreenchido)
            {
                AddErroDeValidacao("valor não pode ser definido", "o Id da entidade só pode ser definido pelo servidor");
                return;
            }

            command.Id = Guid.NewGuid();
            CommandHandlerHelper.DefinirDadosDoCommandAntesDoMapParaDomainAoRegistrar(command);

            var entity = CommandHandlerHelper.MapearCommandParaDomain(command, ETipoOperacaoCrud.Registrar);
            var resultadoValidacao = await ValidadorService.ValidarAsync(entity);
            if (!resultadoValidacao.EstaValido) return;

            await Repository.RegistrarAsync(entity);
            await CommandHandlerHelper.GerarLogAsync(entity, command, ETipoOperacaoCrud.Registrar);
            await Repository.CommitAsync();

            await CommandHandlerHelper.RealizarOperacaoAposRegistrarAsync(entity, command);
        }
        public async Task HandlerAtualizarAsync(TAtualizarCommand command)
        {
            if (command == null)
            {
                ExceptionHelper.LancarErroException("o comando nao pode ser nulo");
                throw new Exception();
            }
            CommandHandlerHelper.DefinirDadosDoCommandAntesDoMapParaDomainAoAtualizar(command);

            var entity = CommandHandlerHelper.MapearCommandParaDomain(command, ETipoOperacaoCrud.Atualizar);
            var resultadoValidacao = await ValidadorService.ValidarAsync(entity);
            if (!resultadoValidacao.EstaValido) return;

            await CommandHandlerHelper.AtualizarDependentesAsync(command, entity, Repository);
            Repository.Atualizar(entity);
            await CommandHandlerHelper.GerarLogAsync(entity, command, ETipoOperacaoCrud.Atualizar);
            await Repository.CommitAsync();

            await CommandHandlerHelper.RealizarOperacaoAposAtualizarAsync(entity, command);
        }
        public async Task HandlerInativarAsync(EntityInativarCommand command)
        {
            if (command == null)
                ExceptionHelper.LancarErroException("o comando nao pode ser nulo");
            var entity = (await Repository.BuscarPorIdAsync(command.Id))!;
            await CommandHandlerHelper.InativarDependentesAsync(command);
            await Repository.InativarAsync(entity);
            await CommandHandlerHelper.GerarLogAsync(entity, command, ETipoOperacaoCrud.Registrar);
            await Repository.CommitAsync();
        }

        protected void AddErroDeValidacao(string tipo, string mensagem)
        {
            DomainNotification.Add(tipo, mensagem);
        }

        #region set delegates

        public void SetDelegatesDeEntityDependente(
            Action<TRegistrarCommand> definirDadosDoCommandAntesDoMapParaDomainAoRegistrar
            , Action<TAtualizarCommand> definirDadosDoCommandAntesDoMapParaDomainAoAtualizar
            , Func<TAtualizarCommand, TEntity, IEntityRepository<TEntity>, Task> obterDependentesParaAtualizar)
        {
            CommandHandlerDelegate.DefinirDadosDoCommandAntesDoMapParaDomainAoRegistrar = definirDadosDoCommandAntesDoMapParaDomainAoRegistrar;
            CommandHandlerDelegate.DefinirDadosDoCommandAntesDoMapParaDomainAoAtualizar = definirDadosDoCommandAntesDoMapParaDomainAoAtualizar;
            CommandHandlerDelegate.AtualizarDependentesAsync = obterDependentesParaAtualizar;
        }

        public void SetDelegatesDeOperacaoAposFinalizarMetodo(Func<TEntity, TRegistrarCommand, Task> realizarOperacaoAposRegistrarAsync
            , Func<TEntity, TAtualizarCommand, Task> realizarOperacaoAposAtualizarAsync
            , Func<TEntity, EntityInativarCommand, Task> realizarOperacaoAposInativarAsync)

        {
            CommandHandlerDelegate.RealizarOperacaoAposRegistrarAsync = realizarOperacaoAposRegistrarAsync;
            CommandHandlerDelegate.RealizarOperacaoAposAtualizarAsync = realizarOperacaoAposAtualizarAsync;
            CommandHandlerDelegate.RealizarOperacaoAposInativarAsync = realizarOperacaoAposInativarAsync;
        }

        #endregion

    }
}
