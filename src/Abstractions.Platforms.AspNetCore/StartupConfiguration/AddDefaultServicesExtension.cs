using DevOps.Abstractions.Core;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public static class AddDefaultServicesExtension
    {
        public static IServiceCollection AddDefaultServices<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
            => services
                .AddDbConfiguration<TDbContext>(configuration)
                .AddMvc()
                    .AddApplicationPart(typeof(AddDefaultServicesExtension).Assembly)
                    .Services
                .AddScoped<IApplicationBuilderConfigurationService<TDbContext>, ApplicationBuilderConfigurationService<TDbContext>>()
                .Configure<RazorViewEngineOptions>(options =>
                {
                    options.FileProviders.Add(new EmbeddedFileProvider(
                        typeof(AddDefaultServicesExtension).Assembly));
                });
    }
}
