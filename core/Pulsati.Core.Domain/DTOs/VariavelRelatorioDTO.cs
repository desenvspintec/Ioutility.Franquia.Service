using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Pulsati.Core.Domain.DTOs
{
    public class VariavelRelatorioDTO<TRelatorioModel> where TRelatorioModel : class
    {
        public VariavelRelatorioDTO(string nome, Func<TRelatorioModel, string> valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public string NomeFormatado { get => $"@{Nome.ToLower()}"; }
        public Func<TRelatorioModel, string> Valor { get; private set; }
    }
}
