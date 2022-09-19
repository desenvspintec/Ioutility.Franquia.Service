using Ioutility.Franquias.Domain.Procedimentos.Enums;
using Ioutility.Franquias.Domain.Procedimentos.Models;

namespace Ioutility.Franquias.Domain.Procedimentos.DTOs
{
    public class ProcedimentoListagemQuery
    {
        public string? Chave { get; set; }
        public EProcedimentoStatus? Status { get; set; }
        public EEspecialidade? Especialidade { get; set; }
        public Guid? TipoProcedimentoId { get; set; }
        public ETipoComissao? TipoComissao { get; set; }
    }
}
