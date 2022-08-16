using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.DTOs.ValueObjects;

namespace Ioutility.Franquias.Domain.Franquias.DTOs
{
    public class FranquiaDTO : EntityBasicDTO
    {
        public EnderecoVODTO Endereco { get; set; }
        public DadoBancarioDTO DadoBancario { get; set; }
    }
}
