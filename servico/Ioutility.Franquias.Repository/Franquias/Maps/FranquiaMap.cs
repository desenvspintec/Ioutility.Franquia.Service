using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Repository.ContextMaps;
using Pulsati.Core.Repository.ContextMaps.ValueObjects;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Repository.DbContexts;
using Ioutility.Franquias.Domain.Franquias.DTOs;

namespace Ioutility.Franquias.Repository.Franquias.Maps
{
    public class FranquiaMap : EntityBasicMap<Franquia>
    {
        public override void Configure(EntityTypeBuilder<Franquia> builder)
        {
            builder.Property(franquia => franquia.Telefone).IsRequired().HasMaxLength(Constante.QUANTITADE_CARACTERIES_PARA_TELEFONE);
            builder.Property(franquia => franquia.CelularWhatsApp).HasMaxLength(Constante.QUANTITADE_CARACTERIES_PARA_TELEFONE);
            builder.Property(franquia => franquia.Cnpj).IsRequired().HasMaxLength(Constante.QUANTITADE_CARACTERIES_PARA_CNPJ);
            //builder.OwnsOne(franquia => franquia.RazaoSocial, StringPesquisavelVOMap.StringPesquisavelMap<Franquia>(true, MaxLengthPadrao));
            //builder.OwnsOne(franquia => franquia.Email, StringPesquisavelVOMap.StringPesquisavelMap<Franquia>(true, MaxLengthPadrao));

            builder.OwnsOne(franquia => franquia.Acesso, franquiaAcessoBuilder => {
                franquiaAcessoBuilder.Property(fraAcesso => fraAcesso.FranquiaStatus);
            });
            builder.OwnsOne(franquia => franquia.DadosBancarios, dadosBancariosBuilder => {
                dadosBancariosBuilder.Property(dBancrio => dBancrio.Agencia).HasMaxLength(MaxLengthPadrao);
                dadosBancariosBuilder.Property(dBancrio => dBancrio.Conta).HasMaxLength(MaxLengthPadrao);
                dadosBancariosBuilder.Property(dBancrio => dBancrio.ChavePix).HasMaxLength(MaxLengthPadrao);
            });

            builder.OwnsOne(franquia => franquia.Endereco, EnderecoVOMap.EnderecoMap<Franquia>());

            builder.OwnsOne(franquia => franquia.BusinessPay, franquiaBusinessPayBuilder => {
                franquiaBusinessPayBuilder.Property(businessPay => businessPay.NrVendasMes).HasMaxLength(MaxLengthPadrao);
                franquiaBusinessPayBuilder.Property(businessPay => businessPay.ConfiguracaoCartao).HasMaxLength(MaxLengthPadrao);
            });

            builder.Property(franquia => franquia.CodigoVirtual).HasMaxLength(MAX_LENGTH_PADRAO_DB);

            base.Configure(builder);
        }
    }
}
