using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public interface IDatabaseConfigurationService<TDbContext> : IStartupConfigurationService<TDbContext> where TDbContext : DbContext
    {
    }
}
