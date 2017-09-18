using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.Core.Services
{
    public static class AddGenericServicesExtension
    {
        public static IServiceCollection AddGenericServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped(typeof(ICacheService<>), typeof(CacheService<>))
                .AddScoped(typeof(ICacheWithDefaultKeysService<>), typeof(CacheWithDefaultKeysService<>))
                .AddScoped(typeof(IDirectoryParseMapToParentService<,>), typeof(DirectoryParseMapToParentService<,>))
                .AddScoped(typeof(IDirectoryParseService<>), typeof(DirectoryParseService<>))
                .AddScoped(typeof(IEntityKeyValuesService<>), typeof(EntityKeyValuesService<>))
                .AddScoped(typeof(IFileParseService<>), typeof(FileParseService<>))
                .AddScoped(typeof(IRepository<,>), typeof(CachedRepository<,>))
                .AddScoped(typeof(IUpsertService<,>), typeof(UpsertService<,>))
                .AddScoped(typeof(IUpsertListService<,>), typeof(UpsertListService<,>))
                .AddScoped(typeof(IUpsertMappedListService<,,>), typeof(UpsertMappedListService<,,>));
    }
}
