using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Procedimentos.Interfaces;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Ioutility.Franquias.Repository.DbContexts;
using Ioutility.Franquias.Repository.Franquias.Repositories;
using Ioutility.Franquias.Repository.Procedimentos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Repository.Repositories;

namespace Ioutility.Franquias.Repository.IoC
{
    public static class RepositoryRegistrarDI
    {
        public static IServiceCollection AddFranquiaRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, FranquiaDb>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFranquiaRepository, FranquiaRepository>();
            services.AddScoped<IEntityQueryRepository<Franquia>, FranquiaRepository>();

            services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
            services.AddScoped<IEntityQueryRepository<Procedimento>, ProcedimentoRepository>();

            services.AddScoped<IEntityRepository<TipoProcedimento>, EntityBasicRepository<TipoProcedimento>>();
            services.AddScoped<IEntityQueryRepository<TipoProcedimento>, EntityBasicRepository<TipoProcedimento>>();

            return services;
        }
    }
}
