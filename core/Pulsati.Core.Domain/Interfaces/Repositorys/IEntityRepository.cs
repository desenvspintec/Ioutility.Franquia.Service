using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Pulsati.Core.Domain.Interfaces.Repositorys
{
    public interface IEntityRepository<TEntity> : IEntityQueryRepository<TEntity>, IAsyncDisposable where TEntity : IEntity
    {

        Task RegistrarAsync(TEntity entity);
        Task RegistrarRangeAsync(IEnumerable<TEntity> entitys);
        void Atualizar(TEntity entity);
        void AtualizarRange(IEnumerable<TEntity> entitys);
        Task InativarPorIdAsync(Guid id);
        Task InativarAsync(TEntity entity);
        Task ExcluirPorIdAsync(Guid id);
        void Excluir(TEntity entity);
        void ExcluirRange(IEnumerable<TEntity> entitys);
        Task ExcluirDependenciasAsync<TDependencia>(IEnumerable<TDependencia> entitysDependentes) where TDependencia : class, IEntity;
        Task RegistrarDependenciasAsync<TDependencia>(IEnumerable<TDependencia> entitysDependency) where TDependencia : class, IEntity;
        void AtualizarDependenciaEntityUmPraUm<TDependencia>(TDependencia entityDependency) where TDependencia : class, IEntity;
        Task<bool> CommitAsync();
    }
}
