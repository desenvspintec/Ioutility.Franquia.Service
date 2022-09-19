using Pulsati.Core.Domain.DTOs.ValueObjects;
using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Models;

namespace Pulsati.Core.Domain.ValueObjects
{
    public class DocumentoFederalVO : Entity<DocumentoFederalVO>
    {
        // EF
        private DocumentoFederalVO(){}
        public DocumentoFederalVO(ETipoDocumentoRegistroFederal tipo, string valor)
        {
            _baseConstrutor(tipo, valor);
        }
        public DocumentoFederalVO(DocumentoFederalVODTO registroFederalDto)
        {

            var tipo = registroFederalDto != null ? registroFederalDto.Tipo : ETipoDocumentoRegistroFederal.Cnpj;
            var valor = registroFederalDto != null ? registroFederalDto.Valor : "";
            _baseConstrutor(tipo, valor);
        }

        private void _baseConstrutor(ETipoDocumentoRegistroFederal tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor ?? "";
        }
      
        public ETipoDocumentoRegistroFederal Tipo { get; private set; }
        public string TipoTexto
        {
            get
            {
                string propriedade = Tipo switch
                {
                    ETipoDocumentoRegistroFederal.Cpf => "CPF",
                    ETipoDocumentoRegistroFederal.Cnpj => "CNPJ",
                    ETipoDocumentoRegistroFederal.Sei => "CEI",
                    _ => "Erro ao cadastrar propriedade numero de documento",
                };
                return propriedade;

            }
        }
        public string Valor { get; private set; }
        public override string DisplayNameTypeOf() => "Documento de Registro Federal";
    }
}
