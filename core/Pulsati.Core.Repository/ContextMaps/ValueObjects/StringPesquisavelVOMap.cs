using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.ValueObjects.StringPesquisavel;

namespace Pulsati.Core.Repository.ContextMaps.ValueObjects
{
    public static class StringPesquisavelVOMap
    {
        public static Action<OwnedNavigationBuilder<TEntityPai, StringPesquisavel>> StringPesquisavelMap<TEntityPai>(bool requied, int? maxLength) where TEntityPai : class, IEntity
        {
            return stringPesquisavelBuilder =>
            {
                if (requied)
                {
                    stringPesquisavelBuilder.Property(stringPesquisavel => stringPesquisavel.ValorQuery).IsRequired();
                    stringPesquisavelBuilder.Property(stringPesquisavel => stringPesquisavel.Valor).IsRequired();
                }
                if (maxLength.HasValue)
                {
                    stringPesquisavelBuilder.Property(stringPesquisavel => stringPesquisavel.ValorQuery).HasMaxLength(maxLength.Value);
                    stringPesquisavelBuilder.Property(stringPesquisavel => stringPesquisavel.Valor).HasMaxLength(maxLength.Value);
                }
            };
        }
    }
}
