using Microsoft.EntityFrameworkCore;
using System;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public class DatabaseConfigurationService<TDbContext> : IDatabaseConfigurationService<TDbContext>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public DatabaseConfigurationService(TDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Configure() => _context.Database.Migrate();
    }
}
