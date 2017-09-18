using DevOps.Abstractions.SourceCode.Solutions.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework
{
    public class SourceCodeTypeDeclarationsDbContext : SourceCodeSolutionsDbContext
    {
        public SourceCodeTypeDeclarationsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddIndexes(modelBuilder);
        }

        private void AddIndexes(ModelBuilder modelBuilder)
        {
        }
    }
}
