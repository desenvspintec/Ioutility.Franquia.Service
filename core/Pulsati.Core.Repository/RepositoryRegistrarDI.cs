using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Repositorys;

namespace Pulsati.Core.Repository
{
    public static class RepositoryResgistrarDI
    {
        public static IServiceCollection AddCoreRepositorys(this IServiceCollection services)
        {
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            return services;
        }
    }
}
