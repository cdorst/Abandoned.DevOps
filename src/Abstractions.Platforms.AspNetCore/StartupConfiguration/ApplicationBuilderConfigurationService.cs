using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public class ApplicationBuilderConfigurationService<TDbContext> : IApplicationBuilderConfigurationService<TDbContext>
        where TDbContext : DbContext
    {
        //private readonly IDatabaseConfigurationService<TDbContext> _database;

        //public ApplicationBuilderConfigurationService(
        //    IDatabaseConfigurationService<TDbContext> database)
        //{
        //    _database = database ?? throw new ArgumentNullException(nameof(database));
        //}
        //public void Configure()
        //{
        //    _database.Configure();
        //}

        public void Configure(IApplicationBuilder app)
        {
            
        }
    }
}
