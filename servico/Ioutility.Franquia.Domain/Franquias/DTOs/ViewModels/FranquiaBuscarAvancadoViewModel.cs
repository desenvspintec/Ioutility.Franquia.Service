using Ioutility.Franquias.Domain.Franquias.Enums;

namespace Ioutility.Franquias.Domain.Franquias.DTOs.ViewModels
{
    public class FranquiaBuscarAvancadoViewModel
    {
        public string? Nome { get; set; }
        public EFranquiaStatus? FranquiaStatus { get; set; }
    }
}
