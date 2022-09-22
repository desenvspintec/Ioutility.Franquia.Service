using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Repository.Repositories;
using Ioutility.Franquias.Domain.Franquias.ViewModels;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;

namespace Ioutility.Franquias.Repository.Franquias.Repositories
{
    public class FranquiaRepository : EntityBasicRepository<Franquia>, IFranquiaRepository
    {
        
        public FranquiaRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        protected override IQueryable<IEntityBasicDTO> OtimizarQueryBuscarTodosOverrider(IQueryable<Franquia> query)
        {
            return query.Select(query => new FranquiaListagemDTO()
            {
                Id = query.Id,
                Cnpj = query.Cnpj,
                Email = query.Email,
                Nome = query.Nome,
                Telefone = query.Telefone,
                FranquiaStatus = query.Acesso.FranquiaStatus,
                CodFranquia = query.CodigoVirtual,
                ImagemFranquia = query.CaminhoImagem
            });
        }
        public async Task<IEnumerable<FranquiaListagemDTO>> BuscarAvancado(FranquiaBuscarAvancadoViewModel queryModel)
        {
            string palavraChave = queryModel.Nome!.FormatarParaBusca();
            var query = BuscarTodosQuery();
            query = query.Where(franquia
                => franquia.NomeQuery.Contains(palavraChave)
                || franquia.Cnpj.Contains(palavraChave)
                //|| fornecedor.Email.ValorQuery.Contains(palavraChave)
                //|| fornecedor.RazaoSocial.ValorQuery.Contains(palavraChave)

            );
            query = AddFiltroPorStatus(queryModel, query);


            if (queryModel.Chave!.EstaPreenchido())
            {
                var codigoQuery = queryModel.Chave!.FormatarParaBusca();
                query = query.Where(franquia => franquia.CodigoVirtual.Contains(codigoQuery));
            }

            var queryOtimizada = OtimizarQueryBuscarTodosOverrider(query);
            return (await queryOtimizada.ToListAsync()).Cast<FranquiaListagemDTO>();
        }

        private static IQueryable<Franquia> AddFiltroPorStatus(FranquiaBuscarAvancadoViewModel queryModel, IQueryable<Franquia> query)
        {
            if (!queryModel.Status.EstaNulo())
                query = query.Where(franquia => franquia.Acesso.FranquiaStatus == queryModel.Status);
            return query;
        }

    }
}
