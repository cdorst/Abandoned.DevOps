using DevOps.Abstractions.Core.Services;
using DevOps.Abstractions.SourceCode.EntityFramework;
using DevOps.Abstractions.SourceCode.Solutions.EntityFramework.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework
{
    public static class AddSourceCodeSolutionsServicesExtension
    {
        public static IServiceCollection AddSourceCodeSolutionsServices<TDbContext>(this IServiceCollection serviceCollection, IConfiguration config)
            where TDbContext : SourceCodeSolutionsDbContext
            => serviceCollection
                .AddSourceCodeServices<TDbContext>(config)
                .AddScoped<IUpsertService<TDbContext, NuGetFeed>, NuGetFeedUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, Project>, ProjectUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, ProjectFile>, ProjectFileUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, Solution>, SolutionUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, SolutionFile>, SolutionFileUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, SolutionFolder>, SolutionFolderUpsertService<TDbContext>>();
    }
}
