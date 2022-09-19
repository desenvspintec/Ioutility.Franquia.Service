using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.UnidadeTests.Models.Validacoes;
using System;

namespace Cn.Core.Domain.Tests.Models
{
    public class EntityDependenteTeste : Entity<EntityDependenteTeste>
    {
        public EntityDependenteTeste(Guid id, Guid entityTesteId, Guid entityTeste2Id): base(id)
        {
            EntityTesteId = entityTesteId;
            EntityTeste2Id = entityTeste2Id;
        }

        public Guid EntityTesteId { get; private set; }
        public Guid EntityTeste2Id { get; private set; }

        public override string DisplayNameTypeOf()
        {
            return "Entity dependente teste";
        }

        protected override void SetValidacoes()
        {
            AddValidacao(new EntityDependenteTesteValidacaoCommand(this));
            base.SetValidacoes();
        }
    }
}
