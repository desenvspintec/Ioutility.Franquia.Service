using Ioutility.Franquias.Api.Config.Autenticacao;
using Ioutility.Franquias.Api.Config.Automapper;
using Ioutility.Franquias.Api.Services;
using Ioutility.Franquias.DI;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.Interfaces;

namespace Ioutility.Franquias.Api.Config.IoC
{
    public static class ApiRegistrarDI
    {
        public static IServiceCollection AddFranquiaFullServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFranquiaServices(configuration);
            services.AddScoped<UsuarioHttpRequest, FranquiaUsuarioHttpResquest>();
            services.AddScoped<IDisplayNameService, DisplayNameServices>();

            services.AddAutoMapper(mapper => mapper.AddProfiles(AutoMapperConfiguration.RegisterMappings()));

            return services;
        }
    }
}
