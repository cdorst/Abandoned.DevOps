using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.Platforms.AspNetCore
{
    public class Server<TDbContext> where TDbContext : DbContext
    {
        public static void Run(string[] args)
            => BuildWebHost(args).Run();

        public static IWebHost BuildWebHost(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup<TDbContext>>()
                .Build();
    }
}
