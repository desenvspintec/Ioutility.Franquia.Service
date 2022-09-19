using Ioutility.Franquias.Domain.Procedimentos.Enums;
using Pulsati.Core.Domain.DTOs;

namespace Ioutility.Franquias.Domain.Procedimentos.DTOs
{
    public class ProcedimentoListagemViewModel : EntityDTO
    {
        public EProcedimentoStatus ProcedimentoStatus { get; set; }
        public string CodProcedimento { get; set; }
        public string Especialidade { get; set; }
        public string TipoProcedimento { get; set; }
        public double ValorSugerido { get; set; }
        public double ValorMinimo { get; set; }
    }
}
