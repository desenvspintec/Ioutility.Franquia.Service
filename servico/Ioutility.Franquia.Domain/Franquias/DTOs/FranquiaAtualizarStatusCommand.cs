using Pulsati.Core.Domain.DTOs;
using Ioutility.Franquias.Domain.Franquias.Enums;

namespace Ioutility.Franquias.Domain.Franquias.DTOs
{
    public class FranquiaAtualizarStatusCommand : EntityDTO {
        public EFranquiaStatus FranquiaStatus { get; set; }
    }
}
