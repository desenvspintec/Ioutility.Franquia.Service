namespace Ioutility.Franquias.Domain.Franquias.DTOs.Gerais
{
    public class BancoDTO
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public string LabelValue { get => $"{Label} - {Value}"; }
    }
}
