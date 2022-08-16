using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Pulsati.Core.Domain.Interfaces.Validacoes
{
    public interface IEntityComDomainValidacao<TEntity> : IEntity, IObjectComDomainValidacao<TEntity> where TEntity : IEntity
    {
    }

}
