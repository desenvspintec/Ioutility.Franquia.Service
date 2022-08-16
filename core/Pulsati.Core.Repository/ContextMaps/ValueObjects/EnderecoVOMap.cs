using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Pulsati.Core.Repository.ContextMaps.ValueObjects
{
    public static class EnderecoVOMap
    {
        public static Action<OwnedNavigationBuilder<TEntityPai, EnderecoVO>> EnderecoMap<TEntityPai>() where TEntityPai : class, IEntity
        {
            return enderecoBuilder =>
            {
                enderecoBuilder.Property(end => end.Complemento).HasMaxLength(Constante.MAX_LEN_PADRAO);
                enderecoBuilder.Property(end => end.Bairro).HasMaxLength(Constante.MAX_LEN_PADRAO);
                enderecoBuilder.Property(end => end.Cidade).HasMaxLength(Constante.MAX_LEN_PADRAO);
                enderecoBuilder.Property(end => end.Estado).HasMaxLength(Constante.MAX_LEN_PADRAO);
                enderecoBuilder.Property(end => end.Uf).HasMaxLength(EnderecoConstante.UF_CONSTANTE);
                enderecoBuilder.Property(end => end.Cep).HasMaxLength(EnderecoConstante.LENGTH_CEP);
            };
        }
    }
}
