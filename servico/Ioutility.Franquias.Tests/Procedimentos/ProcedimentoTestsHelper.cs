using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Enums;
using Ioutility.Franquias.Domain.Procedimentos.Models;

namespace Ioutility.Franquias.Tests.Testes.Procedimentos
{
    public static class FranquiaTestsHelper
    {
        public static ProcedimentoDTO ObterDTOValido()
        {
            return new ProcedimentoDTO
            {
                ComissaoTipo = ETipoComissao.Fixo,
                ComissaoValor = 1,
                Especialidade = EEspecialidade.EsteticaFacial,
                Id = Guid.Empty,
                TipoProcedimentoId = Guid.NewGuid(),
                ValorCustoAdicional = 1,
                ValorMaximo = 1,
                ValorMinimo = 1,
                ValorSugerido = 1,
            };
        }

        public static ProcedimentoDTO ObterDTOInvalidoLimitesMaximosEstouradosComissaoFixa()
        {
            var dto = new ProcedimentoDTO
            {
                ComissaoTipo = ETipoComissao.Fixo,
                ComissaoValor = 9999999,
                Especialidade = EEspecialidade.EsteticaFacial,
                Id = Guid.Empty,
                TipoProcedimentoId = Guid.NewGuid(),
                ValorCustoAdicional = 9999999,
                ValorMaximo = 9999999,
                ValorMinimo = 9999999,
                ValorSugerido = 9999999,
            };
            dto.ValorSugerido = dto.ValorMaximo + 1;
            return dto;
        }

        public static ProcedimentoDTO ObterDTOInvalidoLimitesMinimosEstouradosComissaoFixa()
        {
            var dto = new ProcedimentoDTO
            {
                ComissaoTipo = ETipoComissao.Fixo,
                ComissaoValor = -1,
                Especialidade = EEspecialidade.EsteticaFacial,
                Id = Guid.Empty,
                TipoProcedimentoId = Guid.NewGuid(),
                ValorCustoAdicional = -1,
                ValorMaximo = -1,
                ValorMinimo = -1,
                ValorSugerido = -1,
            };
            dto.ValorSugerido = dto.ValorMaximo + 1;
            return dto;
        }

        public static ProcedimentoDTO ObterDTOInvalidoLimitesMaximosEstouradosComissaoVariavel()
        {
            return new ProcedimentoDTO
            {
                ComissaoTipo = ETipoComissao.Variavel,
                ComissaoValor = 9999999,
                Especialidade = EEspecialidade.EsteticaFacial,
                Id = Guid.Empty,
                TipoProcedimentoId = Guid.NewGuid(),
                ValorCustoAdicional = 9999999,
                ValorMaximo = 9999999,
                ValorMinimo = 9999999,
                ValorSugerido = 9999999,
            };
        }

        public static ProcedimentoDTO ObterDTOInvalidoLimitesMinimosEstourados()
        {
            return new ProcedimentoDTO
            {
                ComissaoTipo = ETipoComissao.Fixo,
                ComissaoValor = -1,
                Especialidade = EEspecialidade.EsteticaFacial,
                Id = Guid.Empty,
                TipoProcedimentoId = Guid.NewGuid(),
                ValorCustoAdicional = -1,
                ValorMaximo = -1,
                ValorMinimo = -1,
                ValorSugerido = -1,
            };
        }

    }
}
