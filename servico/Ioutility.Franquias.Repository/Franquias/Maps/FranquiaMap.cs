using Ioutility.Franquias.Domain.Franquias.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Repository.ContextMaps;
using Pulsati.Core.Repository.ContextMaps.ValueObjects;

namespace Ioutility.Franquias.Repository.Franquias.Maps
{
    public class FranquiaMap : EntityBasicMap<Franquia>
    {
        public override void Configure(EntityTypeBuilder<Franquia> builder)
        {
            builder.OwnsOne(franquia => franquia.Endereco, EnderecoVOMap.EnderecoMap<Franquia>());
            builder.OwnsOne(franquia => franquia.DadoBancario, dadoBancarioBuilder =>
            {
                dadoBancarioBuilder.Property(dBancrio => dBancrio.Agencia).HasMaxLength(MaxLengthPadrao);
                dadoBancarioBuilder.Property(dBancrio => dBancrio.Conta).HasMaxLength(MaxLengthPadrao);
                dadoBancarioBuilder.Property(dBancrio => dBancrio.ChavePix).HasMaxLength(MaxLengthPadrao);
            });
            base.Configure(builder);
        }
    }
}
