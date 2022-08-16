using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Pulsati.Core.Repositorys
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        protected bool RemoverDependenciaViaSql = true;

        protected EntityRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> BuscarTodosQuery()
        {
            var query = DbSet.Where(entity => entity.Ativo).AsNoTracking();
            query = AddIncludeEmBuscarTodosQueryOverrider(query);
            return query;
        }
        /// <summary>
        /// o retorno do metodo include deve ser atribuido a query que retornará com o operador "=", do contrario, o include nao ocorrerá
        /// exemplo de include:
        ///     query = query.Include(produtoTeste => produtoTeste.Detalhes);
        ///     return query;
        /// </summary>
        /// <param name="query">query a receber o include</param>
        /// <returns>query com include</returns>
        protected virtual IQueryable<TEntity> AddIncludeEmBuscarTodosQueryOverrider(IQueryable<TEntity> query)
        {
            /*
             exemplo de include:
                query = query.Include(produtoTeste => produtoTeste.Detalhes);
                return query;
             IMPORTANTE: a o retorno do metodo include deve ser atribuido a query que retornará com o operador = do contrario, o include nao ocorrerá
           */
            return query;
        }
        public abstract Task<IEnumerable<IEntityBasicDTO>> BuscarOtimizadoPorPalavraChaveAsync(string palavraChave, int? quantidadeResultadoLimite = null);
        public abstract Task<IEnumerable<TEntity>> BuscarPorPalavraChaveAsync(string palavraChave, int? quantidadeResultadoLimite = null);
        public virtual async Task<IList<TEntity>> BuscarTodosAsync()
        {
            return await BuscarTodosQuery().ToListAsync();
        }
        public async Task<TEntity?> BuscarPorIdAsync(Guid id)
        {
            var query = BuscarTodosQuery();
            query = AddIncludeEmBuscarPorIdQueryOverrider(query);
            var entity = await query.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
            return entity;
        }
        /// <summary>
        /// o retorno do metodo include deve ser atribuido a query que retornará com o operador "=", do contrario, o include nao ocorrerá
        /// exemplo de include:
        ///     query = query.Include(produtoTeste => produtoTeste.Detalhes);
        ///     return query;
        /// </summary>
        /// <param name="query">query a receber o include</param>
        /// <returns>query com include</returns>
        protected virtual IQueryable<TEntity> AddIncludeEmBuscarPorIdQueryOverrider(IQueryable<TEntity> query)
        {
            /*
             exemplo de include:
                query = query.Include(produtoTeste => produtoTeste.Detalhes);
                return query;
             IMPORTANTE: a o retorno do metodo include deve ser atribuido a query que retornará com o operador = do contrario, o include nao ocorrerá
             */
            return query;
        }
        public virtual async Task RegistrarAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }
        public virtual async Task RegistrarRangeAsync(IEnumerable<TEntity> entitys)
        {
            await DbSet.AddRangeAsync(entitys);
        }


        /// <summary>
        /// Atualiza entidade no banco de dados. Em Caso de erro de tracking tente sobreescrever o metodo SetarNuloEntitysDepentesOverrider da entidade representada por TEntity e setar os seus dependentes como nulos
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="dependentes"></param>
        /// <returns></returns>
        public virtual void Atualizar(TEntity entity)
        {
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            DbSet.Update(entity);
        }

        public virtual void AtualizarRange(IEnumerable<TEntity> entitys)
        {
            DbSet.UpdateRange(entitys);
        }
        public virtual async Task ExcluirPorIdAsync(Guid id)
        {
            var entity = await BuscarPorIdAsync(id);
            DbSet.Remove(entity!);
        }

        public virtual void Excluir(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        public virtual void ExcluirRange(IEnumerable<TEntity> entitys)
        {
            DbSet.RemoveRange(entitys);

        }
        public async Task InativarPorIdAsync(Guid id)
        {
            var entity = await BuscarPorIdAsync(id);
            await InativarAsync(entity!);
        }

        public Task InativarAsync(TEntity entity)
        {
            entity.Inativar();
            Atualizar(entity);
            return Task.CompletedTask;
        }
        public async Task<bool> CommitAsync()
        {
            return (await DbContext.SaveChangesAsync()) > 0;
        }

        public async Task ExcluirDependenciasAsync<TDependency>(IEnumerable<TDependency> entitysDependency) where TDependency : class, IEntity
        {
            if (!_possuiDependencia(entitysDependency)) return;
            if (RemoverDependenciaViaSql)
            {
                var sql = "";
                foreach (var dependencia in entitysDependency)
                {
                    sql += $"delete from \"{Helper.ObterNomeClasse<TDependency>()}\" where \"Id\" = '{dependencia.Id}';";
                }
                try
                {
                    await DbContext.Database.ExecuteSqlRawAsync($"{sql}");
                }
                catch (Exception exception)
                {
                    throw new Exception("Não é possivel executar o SQL solicitado para excluir dependentes", exception);
                }
                return;
            }
            var dbSetDependence = DbContext.Set<TDependency>();

            dbSetDependence.RemoveRange(entitysDependency);


        }
        public async Task RegistrarDependenciasAsync<TDependencia>(IEnumerable<TDependencia> entitysDependency) where TDependencia : class, IEntity
        {
            if (!_possuiDependencia(entitysDependency)) return;

            var dbSetDependency = DbContext.Set<TDependencia>();
            await dbSetDependency.AddRangeAsync(entitysDependency);

        }
        private bool _possuiDependencia(IEnumerable<object> entitysDependence)
        {
            var possuiDependencia = !(entitysDependence == null || !entitysDependence.Any());
            return possuiDependencia;
        }
        public void AtualizarDependenciaEntityUmPraUm<TDependencia>(TDependencia entityDependency) where TDependencia : class, IEntity
        {
            var dbSetDependency = DbContext.Set<TDependencia>();
            try
            {
                dbSetDependency.Update(entityDependency);
            }
            catch (Exception exception)
            {
                throw new Exception("Não é possivel atualizar a dependencia de 1 para 1", exception);
            }
        }
        public async ValueTask DisposeAsync()
        {
            await DbContext.DisposeAsync();   
        }

    
    }
}
