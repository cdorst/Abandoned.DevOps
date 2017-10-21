using DevOps.Abstractions.SourceCode.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.SourceCode.Solutions.EntityFramework
{
    public class SourceCodeSolutionsDbContext : SourceCodeDbContext
    {
        public SourceCodeSolutionsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NuGetFeed> NuGetFeeds { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<SolutionFile> SolutionFiles { get; set; }
        public DbSet<SolutionFolder> SolutionFolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddIndexes(modelBuilder);
        }

        private void AddIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NuGetFeed>()
                .HasIndex(e => new { e.ValueId, e.SolutionId }).IsUnique();
            modelBuilder.Entity<Project>()
                .HasIndex(e => new { e.NameId, e.SolutionFolderId }).IsUnique();
            modelBuilder.Entity<ProjectFile>()
                .HasIndex(e => new { e.FileId, e.ProjectId }).IsUnique();
            modelBuilder.Entity<Solution>()
                .HasIndex(e => new { e.NameId }).IsUnique();
            modelBuilder.Entity<SolutionFile>()
                .HasIndex(e => new { e.FileId, e.SolutionFolderId }).IsUnique();
        }
    }
}
