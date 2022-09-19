using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Enums.Txt;
using Ioutility.Franquias.Domain.Procedimentos.Interfaces;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Repositorys;

namespace Ioutility.Franquias.Repository.Procedimentos.Repositories
{
    public class ProcedimentoRepository : EntityRepository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<IEntityBasicDTO>> BuscarOtimizadoPorPalavraChaveAsync(string palavraChave, int? quantidadeResultadoLimite = null)
        {
            var query = BuscarPorPalavraChaveQuery(palavraChave, quantidadeResultadoLimite).Select(entity => new { entity.Id, entity.TipoProcedimento.Nome, entity.Especialidade });
            var entities = await query.ToListAsync();
            var entitesDTO = entities.Select(entity => new EntityBasicDTO(entity.Id, entity.Nome + " - " + EEspecialidadeTxt.Get(entity.Especialidade)));
            return entitesDTO;
        }
        private IQueryable<Procedimento> BuscarPorPalavraChaveQuery(string palavraChave, int? quantidadeResultadoLimite = null)
        {
            var palavraChaveQuery = palavraChave.FormatarParaBusca();
            var query = BuscarTodosQuery().Where(procedimento => procedimento.TipoProcedimento.NomeQuery.Contains(palavraChaveQuery));
            if (quantidadeResultadoLimite.HasValue)
                query = query.Take(quantidadeResultadoLimite.Value);
            return query;
        }
        public override async Task<IEnumerable<Procedimento>> BuscarPorPalavraChaveAsync(string palavraChave, int? quantidadeResultadoLimite = null)
        {
            return await BuscarPorPalavraChaveQuery(palavraChave, quantidadeResultadoLimite).ToListAsync();
        }

        public async Task<IEnumerable<ProcedimentoListagemViewModel>> BuscarAvancado(ProcedimentoListagemQuery procedimentoListagemQuery)
        {
            var query = BuscarTodosQuery();

            if (procedimentoListagemQuery.Chave!.EstaPreenchido())
            {
                var codigoQuery = procedimentoListagemQuery.Chave!.FormatarParaBusca();
                query = query.Where(procedimento => procedimento.CodigoVirtual.Contains(codigoQuery));
            }

            if (procedimentoListagemQuery.Status.HasValue)
                query = query.Where(procedimento => procedimento.Status == procedimentoListagemQuery.Status.Value);
            
            if (procedimentoListagemQuery.Especialidade.HasValue)
                query = query.Where(procedimento => procedimento.Especialidade == procedimentoListagemQuery.Especialidade.Value);

            if (procedimentoListagemQuery.TipoProcedimentoId.HasValue)
                query = query.Where(procedimento => procedimento.TipoProcedimentoId == procedimentoListagemQuery.TipoProcedimentoId.Value);
            
            if (procedimentoListagemQuery.TipoComissao.HasValue)
                query = query.Where(procedimento => procedimento.Comissao.Tipo == procedimentoListagemQuery.TipoComissao.Value);

            var queryViewModel = query.Select(procedimento =>
                new ProcedimentoListagemViewModel()
                {
                    Id = procedimento.Id,
                    Especialidade = EEspecialidadeTxt.Get(procedimento.Especialidade),
                    TipoProcedimento = procedimento.TipoProcedimento.Nome,
                    ValorMinimo = procedimento.Valor.Minimo,
                    ValorSugerido = procedimento.Valor.Sugerido,
                    CodProcedimento = procedimento.CodigoVirtual
                }
            );

            return await queryViewModel.ToListAsync();
        }
    }
}
