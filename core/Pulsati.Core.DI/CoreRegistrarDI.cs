using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.Domain;
using Pulsati.Core.Repository;

namespace Pulsati.Core.DI
{
    public static class CoreRegistrarDI
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCoreDomain();
            services.AddCoreRepositorys();

            return services;
        }
    }
}