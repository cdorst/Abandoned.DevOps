using DevOps.Abstractions.BusinessObjects.EntityFramework;
using DevOps.Abstractions.BusinessObjects.Simplified.Json.Services.Mapping;
using DevOps.Abstractions.BusinessObjects.Simplified.Servies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Json
{
    public static class AddSimplifiedJsonBusinessObjectsServicesExtension
    {
        public static IServiceCollection AddSimplifiedJsonBusinessObjectsServices<TDbContext>(this IServiceCollection serviceCollection, IConfigurationRoot config)
            where TDbContext : BusinessObjectsDbContext
            => serviceCollection
                .AddMappingServices()
                .AddSimplifiedBusinessObjectsServices<TDbContext>(config)
                .Configure<JsonBusinessObjectsOptions>(config.GetSection(nameof(JsonBusinessObjectsOptions)));
    }
}
