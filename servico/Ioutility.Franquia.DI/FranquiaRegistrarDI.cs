using Ioutility.Franquias.Domain.IoC;
using Ioutility.Franquias.Repository.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.DI;

namespace Ioutility.Franquias.DI
{
    public static class FranquiaRegistrarDI
    {
        public static IServiceCollection AddFranquiaServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore();
            services.AddFranquiaRepository(configuration);
            services.AddFranquiaDomain();
            return services;

        }
    }
}
