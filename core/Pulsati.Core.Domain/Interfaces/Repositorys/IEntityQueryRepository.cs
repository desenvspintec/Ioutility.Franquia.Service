using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Pulsati.Core.Domain.Interfaces.Repositorys
{
    public interface IEntityQueryRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> BuscarPorIdAsync(Guid id);
        Task<IList<TEntity>> BuscarTodosAsync();
        Task<IEnumerable<IEntityBasicDTO>> BuscarOtimizadoPorPalavraChaveAsync(string palavraChave, int? quantidadeResultadoLimite = null);
        Task<IEnumerable<TEntity>> BuscarPorPalavraChaveAsync(string palavraChave, int? quantidadeResultadoLimite = null);


    }
}
