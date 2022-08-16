using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Models;

namespace Pulsati.Core.Domain.Interfaces.Validacoes
{
    public interface IValidacaoCommand<TEntity>
    {
        Task<ResultadoValidacao> ValidarAsync(TEntity entity);
    }
}
