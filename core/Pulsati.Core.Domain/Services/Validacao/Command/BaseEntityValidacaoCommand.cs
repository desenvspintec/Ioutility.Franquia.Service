using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.Services.Validacao.Command
{
    //public abstract class BaseEntityValidacaoCommand<TEntity> : AbstractValidator<TEntity>, IValidadorDomainCommand<TEntity> where TEntity : IEntity, IEntityComDomainValidacao<TEntity>
    public abstract class BaseEntityValidacaoCommand<TEntity> : BaseObjectValidacaoCommand<TEntity> where TEntity : IEntityComDomainValidacao<TEntity>
    {

        protected BaseEntityValidacaoCommand(TEntity entity): base(entity)
        {
        }
    }

}
