using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Mapping
{
    public static class AddMappingServicesExtension
    {
        public static IServiceCollection AddMappingServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped<IMappingService<ConceptDefinition, Concept>, ConceptMappingService>()
                .AddScoped<IMappingService<DomainDefinition, Domain>, DomainMappingService>()
                .AddScoped<IMappingService<PropertyDefinition, ConceptProperty>, PropertyMappingService>()
                .AddScoped<IMappingService<SchemaDefinition, Schema>, SchemaMappingService>()
                .AddScoped<IMappingService<SystemDefinition, System>, SystemMappingService>();
    }
}
