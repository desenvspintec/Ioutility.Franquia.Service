namespace Pulsati.Core.Domain.Enums.EnumText
{
    public static class EChavePixTxt
    {
        public static string Get(ETipoChavePix entity, string valorTxt)
        {
            return entity switch
            {
                ETipoChavePix.Cpf => Convert.ToUInt64(valorTxt).ToString(@"000\.000\.000\-00"),
                ETipoChavePix.Cnpj => Convert.ToUInt64(valorTxt).ToString(@"00\.000\.000\/0000\-00"),
                ETipoChavePix.Telefone => Convert.ToUInt64(valorTxt).ToString(@"\(00\)\ 0 0000\-0000"),
                _ => "Chave pix não definida"
            };
        }
    }
}
