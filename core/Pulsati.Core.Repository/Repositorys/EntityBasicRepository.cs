using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Repositorys;

namespace Pulsati.Core.Repository.Repositorys
{
    public class EntityBasicRepository<TEntity> : EntityRepository<TEntity> where TEntity : class, IEntityBasic
    {
        public EntityBasicRepository(DbContext dbContext) : base(dbContext)
        {
        }

        private IQueryable<TEntity> _buscarPorPalavraChaveQuery(string nome, int? quantidadeResultadoLimite = null)
        {
            //var teste = BuscarTodosQuery().Select(x => new EntityBasicDTO() { })
            var nomeQuery = nome.FormatarParaBusca();
            var query = BuscarTodosQuery().Where(entity => entity.NomeQuery.Contains(nomeQuery));
            if (quantidadeResultadoLimite.HasValue)
                query = query.Take(quantidadeResultadoLimite.Value);
            return query;
        }
        public override async Task<IEnumerable<IEntityBasicDTO>> BuscarOtimizadoPorPalavraChaveAsync(string nome, int? quantidadeResultadoLimite = null)
        {
            var query = _buscarPorPalavraChaveQuery(nome, quantidadeResultadoLimite);
            var queryOtimizada = OtimizarQueryBuscarTodosOverrider(query);
            var resultado = await queryOtimizada.ToListAsync();
            return resultado;
        }

        protected virtual IQueryable<IEntityBasicDTO> OtimizarQueryBuscarTodosOverrider(IQueryable<TEntity> query)
        {
            return query.Select(entity => new EntityBasicDTOQuery{ Id = entity.Id, Nome = entity.Nome });
        }

        public override async Task<IEnumerable<TEntity>> BuscarPorPalavraChaveAsync(string nome, int? quantidadeResultadoLimite = null)
        {
            var resultado = await  _buscarPorPalavraChaveQuery(nome, quantidadeResultadoLimite).ToListAsync();
            return resultado;

        }
    }
}
