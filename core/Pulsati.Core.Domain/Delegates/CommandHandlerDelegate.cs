using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Pulsati.Core.Domain.Delegates
{
    public class CommandHandlerDelegate<TEntity, TRegistrarCommand, TAtualizarCommand>
         where TEntity : IEntity
         where TRegistrarCommand : IEntityDTO
         where TAtualizarCommand : IEntityDTO
    {

        public Action<TRegistrarCommand> DefinirDadosDoCommandAntesDoMapParaDomainAoRegistrar { get; set; }
        public Action<TAtualizarCommand> DefinirDadosDoCommandAntesDoMapParaDomainAoAtualizar { get; set; }
        public Func<TAtualizarCommand, TEntity, IEntityRepository<TEntity>, Task> AtualizarDependentesAsync { get; set; }

        public Func<TRegistrarCommand, TEntity> MapearRegistrarCommandParaDomain { get; set; }
        public Func<TAtualizarCommand, TEntity> MapearAtualizarCommandParaDomain { get; set; }

        public Func<TEntity, TRegistrarCommand, Task>? RealizarOperacaoAposRegistrarAsync { get; set; }
        public Func<TEntity, TAtualizarCommand, Task>? RealizarOperacaoAposAtualizarAsync { get; set; }
        public Func<TEntity, EntityInativarCommand, Task>? RealizarOperacaoAposInativarAsync { get; set; }

        public Func<EntityInativarCommand, Task> InativarDependentesAsync { get; set; }

    }
}
