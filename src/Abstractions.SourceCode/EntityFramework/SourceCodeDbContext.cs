using DevOps.Abstractions.BusinessObjects.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.SourceCode.EntityFramework
{
    public class SourceCodeDbContext : BusinessObjectsDbContext
    {
        public SourceCodeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<FileContent> FileContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddIndexes(modelBuilder);
        }

        private void AddIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .HasIndex(e => new { e.NameId, e.PathId }).IsUnique();
            modelBuilder.Entity<FileContent>()
                .HasIndex(e => new { e.ContentId }).IsUnique();
        }
    }
}
