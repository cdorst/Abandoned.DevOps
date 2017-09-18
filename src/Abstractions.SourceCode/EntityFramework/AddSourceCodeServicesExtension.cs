using DevOps.Abstractions.BusinessObjects.EntityFramework;
using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.SourceCode.EntityFramework.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.SourceCode.EntityFramework
{
    public static class AddSourceCodeServicesExtension
    {
        public static IServiceCollection AddSourceCodeServices<TDbContext>(this IServiceCollection serviceCollection, IConfiguration config)
            where TDbContext : SourceCodeDbContext
            => serviceCollection
                .AddBusinessObjectsServices<TDbContext>(config)
                .AddScoped<IUpsertService<TDbContext, File>, FileUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, FileContent>, FileContentUpsertService<TDbContext>>();
    }
}
