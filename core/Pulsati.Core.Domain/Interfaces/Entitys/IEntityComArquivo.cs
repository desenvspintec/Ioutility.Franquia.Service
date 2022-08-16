using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.Interfaces.Entitys
{
    public interface IEntityComArquivo
    {
        public IReadOnlyCollection<InfoArquivoDTO> ObterTodosArquivosComDiretorio();
    }
}
