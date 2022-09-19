using Ioutility.Franquias.Domain.Procedimentos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Repository.ContextMaps;

namespace Ioutility.Franquias.Repository.Procedimentos.Maps
{
    public class ProcedimentoMap : EntityMap<Procedimento>
    {
        public override void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.OwnsOne(procedimento => procedimento.Comissao, comissaoBuilder =>
            {
                comissaoBuilder.Property(comissao => comissao.Valor).IsRequired();
            });
            builder.OwnsOne(procedimento => procedimento.Valor, valorBuilder =>
            {
                valorBuilder.Property(valor => valor.Sugerido).IsRequired();
                valorBuilder.Property(valor => valor.Minimo).IsRequired();
                valorBuilder.Property(valor => valor.Maximo).IsRequired();
                valorBuilder.Property(valor => valor.CustoAdicional).IsRequired();
            });

            builder.Property(procedimento => procedimento.CodigoVirtual).HasMaxLength(MAX_LENGTH_PADRAO_DB);
            builder.HasOne(procedimento => procedimento.TipoProcedimento).WithMany(tipo => tipo.Procedimentos).HasForeignKey(procedimento => procedimento.TipoProcedimentoId);
            base.Configure(builder);
        }
    }
}
