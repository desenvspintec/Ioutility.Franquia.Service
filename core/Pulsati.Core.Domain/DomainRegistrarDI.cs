using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.EventSources;

namespace Pulsati.Core.Domain
{
    public static class DomainRegistrarDI
    {
        public static IServiceCollection AddCoreDomain(this IServiceCollection services)
        {
            services.AddScoped<DomainNotification>();
            services.AddScoped<EventStoreService>();
            return services;
        }
    }
}
