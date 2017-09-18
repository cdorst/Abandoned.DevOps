using Microsoft.AspNetCore.Builder;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public interface IApplicationBuilderConfigurationService<TDbContext>
    {
        void Configure(IApplicationBuilder app);
    }
}
