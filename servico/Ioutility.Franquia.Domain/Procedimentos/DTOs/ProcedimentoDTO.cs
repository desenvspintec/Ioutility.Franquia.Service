using Ioutility.Franquias.Domain.Procedimentos.Enums;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.DTOs;

namespace Ioutility.Franquias.Domain.Procedimentos.DTOs
{
    public class ProcedimentoDTO : EntityDTO
    {
        public EEspecialidade Especialidade { get; set; }
        public Guid TipoProcedimentoId { get; set; }

        public double ValorSugerido { get; set; }
        public double ValorMinimo { get; set; }
        public double ValorMaximo { get; set; }
        public double ValorCustoAdicional { get; set; }

        public ETipoComissao ComissaoTipo { get; set; }
        public double ComissaoValor { get; set; }
    }
}
