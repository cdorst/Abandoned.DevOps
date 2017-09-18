using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public interface IPipelineConfigurationService<TDbContext> : IStartupConfigurationService<TDbContext> where TDbContext : DbContext
    {
    }
}
