using Pulsati.Core.Domain.DisplayNames;

namespace Pulsati.Core.Domain.Interfaces
{
    public interface IDisplayNameService
    {
        IReadOnlyCollection<DisplayName> ObterTodos();
        DisplayName? ObterPorNomePropriedade(string nomePropriedade);
    }
}
