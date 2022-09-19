using Pulsati.Core.Domain.Models;
using System;

namespace Cn.Core.Domain.Tests.Models
{
    public class EntityBasicaTesteNaoFiltraPreposicao : EntityBasic<EntityBasicaTesteNaoFiltraPreposicao>
    {
        public EntityBasicaTesteNaoFiltraPreposicao(Guid id, string nome) : base(id, nome)
        {
        }

        public override string DisplayNameTypeOf()
        {
            return "EntityBasicaTesteNaoFiltraPreposicao";
        }
    }
}
