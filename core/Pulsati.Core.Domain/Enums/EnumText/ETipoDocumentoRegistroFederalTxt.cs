namespace Pulsati.Core.Domain.Enums.EnumText
{
    public static class ETipoDocumentoRegistroFederalTxt
    {
        public static string Get(ETipoDocumentoRegistroFederal valor)
        {
            return valor switch
            {
                ETipoDocumentoRegistroFederal.CertidaoNascimento => "Certidão de nascimento",
                ETipoDocumentoRegistroFederal.CPF => "CPF",
                ETipoDocumentoRegistroFederal.Cnpj => "CNPJ",
                ETipoDocumentoRegistroFederal.Sei => "SEI",
                ETipoDocumentoRegistroFederal.CRO => "CRO",
                _ => "Documento indefinido",
            };
        }
    }
}
