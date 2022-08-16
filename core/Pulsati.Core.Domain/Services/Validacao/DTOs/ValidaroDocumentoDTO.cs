using Pulsati.Core.Domain.Enums;

namespace Pulsati.Core.Domain.Services.Validacao.DTOs
{
    public class ValidaroDocumentoDTO
    {
        public ValidaroDocumentoDTO(ETipoDocumentoRegistroFederal tipoDocumento, string documento)
        {
            Tipo = tipoDocumento;
            Numero = documento;
        }

        public ETipoDocumentoRegistroFederal Tipo { get; private set; }
        public string Numero { get; private set; }

        public override string ToString()
        {
            return Numero;
        }
    }
}
