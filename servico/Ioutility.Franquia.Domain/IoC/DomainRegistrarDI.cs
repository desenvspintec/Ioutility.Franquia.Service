using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Services;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Ioutility.Franquias.Domain.Procedimentos.Services;
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

            services.AddScoped<EntityValidacaoService<Procedimento>, EntityValidacaoService<Procedimento>>();
            services.AddScoped<ProcedimentoCommandHandler>();

            services.AddScoped<EntityValidacaoService<TipoProcedimento>, EntityBasicValidacaoService<TipoProcedimento>>();
            services.AddScoped<EntityCommandHandler<TipoProcedimento, TipoProcedimentoDTO, TipoProcedimentoDTO>>();

            return services;
        }
    }
}
