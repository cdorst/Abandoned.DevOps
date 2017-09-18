using DevOps.Abstractions.Core;
using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.UniqueStrings.EntityFramework.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.UniqueStrings.EntityFramework
{
    public static class AddUniqueStringsServicesExtension
    {
        public static IServiceCollection AddUniqueStringsServices<TDbContext>(this IServiceCollection serviceCollection, IConfiguration config)
            where TDbContext : UniqueStringsDbContext
            => serviceCollection
                .AddDbConfiguration<TDbContext>(config)
                .AddScoped<IUpsertService<TDbContext, AsciiStringReference>, AsciiStringReferenceUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, UnicodeStringReference>, UnicodeStringReferenceUpsertService<TDbContext>>();
    }
}
