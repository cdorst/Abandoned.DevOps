using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Json.Services.Mapping
{
    public static class AddMappingServicesExtension
    {
        public static IServiceCollection AddMappingServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped<IParentMappingService<SchemaDefinition, DomainDefinition>, ParentMappingService<SchemaDefinition, DomainDefinition>>()
                .AddScoped<IParentMappingService<DomainDefinition, SystemDefinition>, ParentMappingService<DomainDefinition, SystemDefinition>>()
                .AddScoped<IParentMappingService<SchemaDefinition, SystemDefinition>, ParentMappingService<SchemaDefinition, SystemDefinition>>();
    }
}
