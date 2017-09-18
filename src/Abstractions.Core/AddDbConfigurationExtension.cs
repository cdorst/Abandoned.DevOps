using DevOps.Abstractions.Core.Options;
using DevOps.Abstractions.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.Core
{
    public static class AddDbConfigurationExtension
    {
        public static IServiceCollection AddDbConfiguration<TDbContext>(this IServiceCollection serviceCollection, IConfiguration config)
            where TDbContext : DbContext
            => serviceCollection
                .AddDbContextPool<TDbContext>(
                    opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")),
                    config.GetValue<int?>("DbConfiguration:PoolSize") ?? 128)
                .AddDistributedMemoryCache()
                .AddGenericServices()
                .AddLogging()
                .Configure<CacheSlidingExpiration>(
                    config.GetSection(nameof(CacheSlidingExpiration)));
    }
}
