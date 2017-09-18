using DevOps.Abstractions.BusinessObjects.EntityFramework.Services.Upsert;
using DevOps.Abstractions.UniqueStrings.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework
{
    public static class AddBusinessObjectsServicesExtension
    {
        public static IServiceCollection AddBusinessObjectsServices<TDbContext>(this IServiceCollection serviceCollection, IConfiguration config)
            where TDbContext : BusinessObjectsDbContext
            => serviceCollection
                .AddUniqueStringsServices<TDbContext>(config)
                .AddUpsertServices<TDbContext>();
    }
}
