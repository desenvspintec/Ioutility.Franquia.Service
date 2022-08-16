using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Pulsati.Core.Repository.ContextMaps
{
    public class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity
    {
        protected readonly int MAX_LENGTH_PADRAO_DB = Constante.MAX_LEN_PADRAO;
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var nomeDaTabela = typeof(TEntity).ToString().Split('.').Last();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataCriacao).IsRequired();
            builder.Property(e => e.Ativo).HasDefaultValue(true);
            builder.Property(e => e.Ativo).IsRequired();

            builder.ToTable(nomeDaTabela);
        }
    }
}
