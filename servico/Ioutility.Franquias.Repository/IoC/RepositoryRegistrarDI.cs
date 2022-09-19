using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Repository.DbContexts;
using Ioutility.Franquias.Repository.Franquias.Repositorys;
using Ioutility.Franquias.Repository.JsonRepositorys.Bancos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Ioutility.Franquias.Repository.IoC
{
    public static class RepositoryRegistrarDI
    {
        public static IServiceCollection AddFranquiaRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, FranquiaDb>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFranquiaRepository, FranquiaRepository>();
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IEntityQueryRepository<Franquia>, FranquiaRepository>();

            return services;
        }
    }
}
