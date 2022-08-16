using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Interfaces.Scopos;

namespace Pulsati.Core.Repository.ContextMaps.Scopos
{
    public class PessoaFisicaMap 
    {
        public static void Map<TPessoaFisica>(EntityTypeBuilder<TPessoaFisica> builder) where TPessoaFisica : class, IPessoaFisica
        {
            builder.Property(pac => pac.Nascimento).IsRequired();
            builder.Property(pac => pac.Telefone).IsRequired().HasMaxLength(Constante.QUANTITADE_CARACTERIES_PARA_TELEFONE);
        }
    }
}
