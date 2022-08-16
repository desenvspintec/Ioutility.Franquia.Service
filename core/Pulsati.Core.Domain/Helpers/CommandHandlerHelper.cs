using AutoMapper;
using Pulsati.Core.Domain.Delegates;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Pulsati.Core.Domain.Helpers
{
    public class CommandHandlerHelper<TEntity, TRegistrarCommand, TAtualizarCommand>
       where TEntity : class, IEntity
       where TRegistrarCommand : IEntityDTO
       where TAtualizarCommand : IEntityDTO
    {
        public readonly IMapper Mapper;
        public readonly EventStoreService EventStoreService;
        public CommandHandlerDelegate<TEntity, TRegistrarCommand, TAtualizarCommand> CommandHandlerDelegate { get; private set; }

        public CommandHandlerHelper(IMapper mapper
            , EventStoreService eventStoreService
            , CommandHandlerDelegate<TEntity, TRegistrarCommand, TAtualizarCommand> commandHandlerDelegate)
        {
            Mapper = mapper;
            EventStoreService = eventStoreService;
            CommandHandlerDelegate = commandHandlerDelegate;
            
        }

        #region Geral
        public TEntity MapearCommandParaDomain(IEntityDTO command, ETipoOperacaoCrud tipoOperacaoCrud)
        {
            try
            {
                if (tipoOperacaoCrud == ETipoOperacaoCrud.Registrar)
                    return BaseMapearRegistrarCommandParaDomain((TRegistrarCommand) command );
                else if (tipoOperacaoCrud == ETipoOperacaoCrud.Atualizar)
                    return BaseMapearAtualizarCommandParaDomain((TAtualizarCommand) command);

                ExceptionHelper.LancarErroException("não foi possivel mapear o comando para dominio, pois a operação solicitada esta inválida. Operação: " + tipoOperacaoCrud);
                throw new Exception();
            }
            catch (Exception exception)
            {
                _gerarErroDeMap<TRegistrarCommand>(exception);
                throw;
            }
        }
        public async Task GerarLogAsync(TEntity entity, object command, ETipoOperacaoCrud tipoOperacaoCrud)
        {
            await EventStoreService.SalvarEventAsync(entity, tipoOperacaoCrud, command);
        }
        private void _gerarErroDeMap<TCommand>(Exception exception)
        {
            var mensagemErro = $"Não foi possivel realizar o Map entre a entidade {typeof(TCommand)} para {typeof(TEntity)}. Mais detalhes: {exception.Message}";
            ExceptionHelper.LancarErroException(mensagemErro);
        }
        #endregion

        #region Registrar
        public void DefinirDadosDoCommandAntesDoMapParaDomainAoRegistrar(TRegistrarCommand command)
        {
            if (CommandHandlerDelegate.DefinirDadosDoCommandAntesDoMapParaDomainAoRegistrar.EstaNulo()) return;
            CommandHandlerDelegate.DefinirDadosDoCommandAntesDoMapParaDomainAoRegistrar.Invoke(command);
        }

        public async Task RealizarOperacaoAposRegistrarAsync(TEntity entity, TRegistrarCommand command)
        {
            if (CommandHandlerDelegate.RealizarOperacaoAposRegistrarAsync.EstaNulo()) return;
            await CommandHandlerDelegate.RealizarOperacaoAposRegistrarAsync.Invoke(entity, command);
        }

        private TEntity BaseMapearRegistrarCommandParaDomain(TRegistrarCommand command)
        {
            if (!CommandHandlerDelegate.MapearRegistrarCommandParaDomain.EstaNulo())
                return CommandHandlerDelegate.MapearRegistrarCommandParaDomain.Invoke(command);

            return Mapper.Map<TEntity>(command);
        }

        #endregion

        #region Atualizar
        public void DefinirDadosDoCommandAntesDoMapParaDomainAoAtualizar(TAtualizarCommand command)
        {
            if (CommandHandlerDelegate.DefinirDadosDoCommandAntesDoMapParaDomainAoAtualizar.EstaNulo()) return;
            CommandHandlerDelegate.DefinirDadosDoCommandAntesDoMapParaDomainAoAtualizar.Invoke(command);
        }
        protected TEntity BaseMapearAtualizarCommandParaDomain(TAtualizarCommand command)
        {
            if (!CommandHandlerDelegate.MapearRegistrarCommandParaDomain.EstaNulo())
                return CommandHandlerDelegate.MapearAtualizarCommandParaDomain.Invoke(command);

            return Mapper.Map<TEntity>(command);
        }

        public async Task AtualizarDependentesAsync(TAtualizarCommand command, TEntity entity, IEntityRepository<TEntity> repository)
        {
            if (CommandHandlerDelegate.AtualizarDependentesAsync.EstaNulo()) return;
            await CommandHandlerDelegate.AtualizarDependentesAsync.Invoke(command, entity, repository);
        }
        public async Task RealizarOperacaoAposAtualizarAsync(TEntity entity, TAtualizarCommand command)
        {
            if (CommandHandlerDelegate.RealizarOperacaoAposAtualizarAsync.EstaNulo()) return;
            await CommandHandlerDelegate.RealizarOperacaoAposAtualizarAsync(entity, command);
        }


        #endregion

        #region Inativar
        public async Task InativarDependentesAsync(EntityInativarCommand command)
        {
            if (CommandHandlerDelegate.InativarDependentesAsync.EstaNulo()) return;
            await CommandHandlerDelegate.InativarDependentesAsync(command);
        }
        #endregion
    }
}
