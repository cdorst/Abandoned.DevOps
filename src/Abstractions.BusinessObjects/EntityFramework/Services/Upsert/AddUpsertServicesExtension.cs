using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert
{
    public static class AddUpsertServicesExtension
    {
        public static IServiceCollection AddUpsertServices<TDbContext>(this IServiceCollection serviceCollection)
            where TDbContext : BusinessObjectsDbContext
            => serviceCollection
                .AddScoped<IUpsertService<TDbContext, Concept>, ConceptUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, ConceptManyOptional>, ConceptManyOptionalUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, ConceptManyRequired>, ConceptManyRequiredUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, ConceptOneOptional>, ConceptOneOptionalUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, ConceptOneRequired>, ConceptOneRequiredUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, ConceptProperty>, ConceptPropertyUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, Domain>, DomainUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, Schema>, SchemaUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, System>, SystemUpsertService<TDbContext>>();
    }
}
