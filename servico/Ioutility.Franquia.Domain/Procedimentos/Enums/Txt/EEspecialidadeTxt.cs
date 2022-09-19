namespace Ioutility.Franquias.Domain.Procedimentos.Enums.Txt
{
    public static class EEspecialidadeTxt
    {
        public static string Get(EEspecialidade especialidade)
        {

            return especialidade switch
            {
                EEspecialidade.ClinicoGeral => "Clinico Geral",
                EEspecialidade.Ortodontia => "Ortodontia",
                EEspecialidade.Endodontia => "Endodontia",
                EEspecialidade.OdontoPediatria => "OdontoPediatria",
                EEspecialidade.Periodontia => "Periodontia",
                EEspecialidade.Implante => "Implante",
                EEspecialidade.Protese => "Protese",
                EEspecialidade.DentistaEstetica => "DentistaEstetica",
                EEspecialidade.EsteticaFacial => "EsteticaFacial",
                _ => $"valor {especialidade} não é valido",
            };
        }
    }
}
