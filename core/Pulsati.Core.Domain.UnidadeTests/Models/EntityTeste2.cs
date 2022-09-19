using Pulsati.Core.Domain.Models;
using System;

namespace Cn.Core.Domain.Tests.Models
{
    public class EntityTeste2 : Entity<EntityTeste>
    {
        public EntityTeste2(Guid id) : base(id)
        {
        }

        public override string DisplayNameTypeOf()
        {
            return "EntityTeste2";
        }
    }
}
