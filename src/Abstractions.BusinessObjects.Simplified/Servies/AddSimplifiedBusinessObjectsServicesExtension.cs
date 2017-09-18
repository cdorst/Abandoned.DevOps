using DevOps.Abstractions.BusinessObjects.EntityFramework;
using DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping;
using DevOps.Abstractions.BusinessObjects.Simplified.Servies.Upsert;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies
{
    public static class AddSimplifiedBusinessObjectsServicesExtension
    {
        public static IServiceCollection AddSimplifiedBusinessObjectsServices<TDbContext>(this IServiceCollection serviceCollection, IConfiguration config)
            where TDbContext : BusinessObjectsDbContext
            => serviceCollection
                .AddBusinessObjectsServices<TDbContext>(config)
                .AddMappingServices()
                .AddUpsertServices<TDbContext>();
    }
}
