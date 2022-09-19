using Pulsati.Core.Domain.Models;
using System;

namespace Cn.Core.Domain.Tests.Models
{
    public class EntityBasicaTesteRepetivel : EntityBasic<EntityBasicaTesteRepetivel>
    {
        public EntityBasicaTesteRepetivel(Guid id, string nome) : base(id, nome)
        {
        }

        public override string DisplayNameTypeOf() => "EntityBasic";
    }
}
