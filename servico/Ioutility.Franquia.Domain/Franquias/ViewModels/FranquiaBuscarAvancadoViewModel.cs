using Ioutility.Franquias.Domain.Franquias.Enums;

namespace Ioutility.Franquias.Domain.Franquias.ViewModels
{
    public class FranquiaBuscarAvancadoViewModel {
        public string? Chave { get; set; }
        public string? Nome { get; set; }
        public EFranquiaStatus? Status { get; set; }
    }
}
