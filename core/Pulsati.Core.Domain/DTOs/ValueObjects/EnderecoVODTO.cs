namespace Pulsati.Core.Domain.DTOs.ValueObjects
{
    public class EnderecoVODTO
    {
       
        public string? Complemento { get; set; }
        public int? Numero { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Arquivos { get; set; }
    }
}
