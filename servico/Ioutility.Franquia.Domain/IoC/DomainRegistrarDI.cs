using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Services;
using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.Domain.Services.CommandHandlers;
using Pulsati.Core.Domain.Services.Validacao;

namespace Ioutility.Franquias.Domain.IoC
{
    public static class DomainRegistrarDI
    {
        public static IServiceCollection AddFranquiaDomain(this IServiceCollection services)
        {
            services.AddScoped<EntityValidacaoService<Franquia>, EntityBasicValidacaoService<Franquia>>();
            services.AddScoped<FranquiaCommandHandler>();

            return services;
        }
    }
}
