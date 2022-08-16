using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.Services.Validacao
{
    public class EntityBasicValidacaoService<TEntity> : EntityValidacaoService<TEntity> where TEntity : IEntityBasic, IEntityComDomainValidacao<TEntity>
    {
        public EntityBasicValidacaoService(DomainNotification domainNotification, IEntityQueryRepository<TEntity> repository) : base(domainNotification)
        {
            AddCommand(new ValidarNaoDuplicidadeCommand<TEntity>(repository));
        }

    }

}
