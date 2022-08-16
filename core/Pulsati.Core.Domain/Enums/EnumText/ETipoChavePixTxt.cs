namespace Pulsati.Core.Domain.Enums.EnumText
{
    public static class ETipoChavePixTxt
    {
        public static string Get(ETipoChavePix valor)
        {
            return valor switch
            {
                ETipoChavePix.Cpf => "CPF",
                ETipoChavePix.Cnpj => "CNPJ",
                ETipoChavePix.Telefone => "Telefone",
                _ => "Chave pix não definida"
            };
        }
    }
}
