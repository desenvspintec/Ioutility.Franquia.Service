using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Repository.Repositorys;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Enums;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.ViewModels;

namespace Ioutility.Franquias.Repository.Franquias.Repositorys
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
                // Email = query.Email.Valor,
                // RazaoSocial = query.RazaoSocial.Valor,
                Nome = query.Nome,
                Telefone = query.Telefone,
                FranquiaStatus = query.Acesso.FranquiaStatus
            });
        }
        public async Task<IEnumerable<FranquiaListagemDTO>> BuscarAvancado(FranquiaBuscarAvancadoViewModel queryModel)
        {
            string palavraChave = queryModel.Nome!.FormatarParaBusca();
            var query = BuscarTodosQuery();
            query = query.Where(fornecedor
                => fornecedor.NomeQuery.Contains(palavraChave)
                || fornecedor.Cnpj.Contains(palavraChave)
                //|| fornecedor.Email.ValorQuery.Contains(palavraChave)
                //|| fornecedor.RazaoSocial.ValorQuery.Contains(palavraChave)

            );
            query = AddFiltroPorStatus(queryModel, query);

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
