using Pulsati.Core.Domain.Models;
using System;

namespace Cn.Core.Domain.Tests.Models
{
    public class EntityBasicaTeste : EntityBasic<EntityBasicaTeste>
    {
        public EntityBasicaTeste(Guid id, string nome) : base(id, nome)
        {
        }

        public override string DisplayNameTypeOf() => "EntityBasicaTeste";
    }
}
