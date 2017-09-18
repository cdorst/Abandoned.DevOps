using DevOps.Abstractions.BusinessObjects.EntityFramework;
using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Servies.Upsert
{
    public static class AddUpsertServicesExtension
    {
        public static IServiceCollection AddUpsertServices<TDbContext>(this IServiceCollection serviceCollection)
            where TDbContext : BusinessObjectsDbContext
            => serviceCollection
                .AddScoped<IUpsertMappedListService<TDbContext, ConceptDefinition, Concept>, UpsertMappedListService<TDbContext, ConceptDefinition, Concept>>()
                .AddScoped<IUpsertMappedListService<TDbContext, DomainDefinition, Domain>, UpsertMappedListService<TDbContext, DomainDefinition, Domain>>()
                .AddScoped<IUpsertMappedListService<TDbContext, PropertyDefinition, ConceptProperty>, UpsertMappedListService<TDbContext, PropertyDefinition, ConceptProperty>>()
                .AddScoped<IUpsertMappedListService<TDbContext, SchemaDefinition, Schema>, UpsertMappedListService<TDbContext, SchemaDefinition, Schema>>()
                .AddScoped<IUpsertMappedListService<TDbContext, SystemDefinition, System>, UpsertMappedListService<TDbContext, SystemDefinition, System>>();
    }
}
