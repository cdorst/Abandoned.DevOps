using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.UniqueStrings.EntityFramework
{
    public class UniqueStringsDbContext : DbContext
    {
        public UniqueStringsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AsciiMaxStringReference> AsciiMaxStringReferences { get; set; }
        public DbSet<AsciiStringReference> AsciiStringReferences { get; set; }
        public DbSet<UnicodeMaxStringReference> UnicodeMaxStringReferences { get; set; }
        public DbSet<UnicodeStringReference> UnicodeStringReferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsciiMaxStringReference>().HasIndex(e => new { e.Hash }).IsUnique();
            modelBuilder.Entity<AsciiStringReference>().HasIndex(e => new { e.Value }).IsUnique();
            modelBuilder.Entity<UnicodeMaxStringReference>().HasIndex(e => new { e.Hash }).IsUnique();
            modelBuilder.Entity<UnicodeStringReference>().HasIndex(e => new { e.Value }).IsUnique();
        }
    }
}
