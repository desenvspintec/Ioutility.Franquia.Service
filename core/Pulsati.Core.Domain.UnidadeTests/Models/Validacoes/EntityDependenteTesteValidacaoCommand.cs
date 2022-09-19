using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.UnidadeTests.Models.Validacoes
{
    public class EntityDependenteTesteValidacaoCommand : BaseEntityValidacaoCommand<EntityDependenteTeste>
    {
        public EntityDependenteTesteValidacaoCommand(EntityDependenteTeste entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao()
        {
            ValidarCampoObrigatorio(entdep => entdep.Id, "Id Dependente");
        }
    }
}
