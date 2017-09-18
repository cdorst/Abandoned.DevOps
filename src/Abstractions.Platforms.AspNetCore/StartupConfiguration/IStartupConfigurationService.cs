using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public interface IStartupConfigurationService<TDbContext> where TDbContext : DbContext
    {
        void Configure();
    }
}
