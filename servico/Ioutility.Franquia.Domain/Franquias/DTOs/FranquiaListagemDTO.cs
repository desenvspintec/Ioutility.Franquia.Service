using Pulsati.Core.Domain.DTOs;
using Ioutility.Franquias.Domain.Franquias.Enums;
using Ioutility.Franquias.Domain.Franquias.Models;

namespace Ioutility.Franquias.Domain.Franquias.DTOs {
    public class FranquiaListagemDTO : EntityBasicDTO {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string CnpjTxt { get => Convert.ToUInt64(Cnpj).ToString(@"00\.000\.000\/0000\-00"); }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TelefoneTxt { get => Convert.ToUInt64(Telefone).ToString(@"\(00\)\ 0000\-0000"); }
        public EFranquiaStatus FranquiaStatus { get; set; }
    }
}
