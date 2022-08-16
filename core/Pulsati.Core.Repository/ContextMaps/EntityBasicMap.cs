using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Pulsati.Core.Repository.ContextMaps
{
    public class EntityBasicMap<TEntity> : EntityMap<TEntity> where TEntity : class, IEntityBasic
    {
        protected int MaxLengthPadrao;
        public EntityBasicMap()
        {
            MaxLengthPadrao = Constante.MAX_LEN_PADRAO;
        }
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Nome).HasMaxLength(MaxLengthPadrao);
            builder.Property(e => e.Nome).IsRequired();

            builder.Property(e => e.NomeQuery).HasMaxLength(MaxLengthPadrao);
            builder.Property(e => e.NomeQuery).IsRequired();

            builder.Property(e => e.NomeSemPreposicaoQuery).HasMaxLength(MaxLengthPadrao);
            builder.Property(e => e.NomeSemPreposicaoQuery).IsRequired();
            base.Configure(builder);
        }
    }
}
