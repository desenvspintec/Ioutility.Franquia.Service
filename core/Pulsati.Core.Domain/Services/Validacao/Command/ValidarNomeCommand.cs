using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.Services.Validacao.Command
{
    public class ValidarNomeCommand<TEntity> : BaseEntityValidacaoCommand<TEntity> where TEntity : IEntityBasic, IEntityComDomainValidacao<TEntity>
    {
        public ValidarNomeCommand(TEntity entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao() => ValidarCampoTextoBasico(entity => entity.Nome);
    }
}
