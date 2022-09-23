using Ioutility.Franquias.Domain.Franquias.DTOs.Gerais;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.DTOs.ValueObjects;
using Ioutility.Franquias.Domain.Franquias.Enums;
using Ioutility.Franquias.Domain.Franquias.Models;

namespace Ioutility.Franquias.Domain.Franquias.DTOs
{
    public class FranquiaDTO : EntityBasicDTO
    {
        public string? CodFranquia { get; set; }
        public string? ImagemFranquia { get; set; }
        public string Cnpj { get; set; }
        public string ResponsavelLegal { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CelularWhatsApp { get; set; }
        public EnderecoVODTO Endereco { get; set; }
        public DadosBancariosVODTO DadosBancarios { get; set; }
        public BusinessPayVODTO? BusinessPay { get; set; }
        public FranquiaAcessoVODTO? Acesso { get; set; }
    }
}
