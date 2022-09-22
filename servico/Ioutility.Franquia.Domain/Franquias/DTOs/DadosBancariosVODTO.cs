using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Enums.EnumText;

namespace Ioutility.Franquias.Domain.Franquias.DTOs
{
    public class DadosBancariosVODTO
    {
        public string BancoId { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public ETipoChavePix TipoChavePix { get; set; }
        public string TipoChavePixTxt { get { return ETipoChavePixTxt.Get(TipoChavePix); } }
        public string ChavePix { get; set; }
    }
}
