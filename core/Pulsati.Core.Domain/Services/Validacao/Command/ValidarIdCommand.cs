using FluentValidation;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.Services.Validacao.Command
{
    public class ValidarIdCommand<TEntity> : BaseEntityValidacaoCommand<TEntity> where TEntity : IEntity, IEntityComDomainValidacao<TEntity>
    {
        public ValidarIdCommand(TEntity entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao() => ValidarCampoObrigatorio(ent => ent.Id);

    }
}
