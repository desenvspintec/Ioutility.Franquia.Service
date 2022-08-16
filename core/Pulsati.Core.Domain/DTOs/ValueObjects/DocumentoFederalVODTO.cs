using Pulsati.Core.Domain.Enums;

namespace Pulsati.Core.Domain.DTOs.ValueObjects
{
    public class DocumentoFederalVODTO
    {
        public ETipoDocumentoRegistroFederal Tipo { get; set; }
        public string Valor { get; set; }
    }
}
