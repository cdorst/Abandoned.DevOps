using DevOps.Abstractions.UniqueStrings.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.BusinessObjects.EntityFramework
{
    public class BusinessObjectsDbContext : UniqueStringsDbContext
    {
        public BusinessObjectsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Concept> Concepts { get; set; }
        public DbSet<ConceptManyOptional> ConceptManyOptionals { get; set; }
        public DbSet<ConceptManyRequired> ConceptManyRequireds { get; set; }
        public DbSet<ConceptOneOptional> ConceptOneOptionals { get; set; }
        public DbSet<ConceptOneRequired> ConceptOneRequireds { get; set; }
        public DbSet<ConceptProperty> ConceptProperties { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<System> Systems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddIndexes(modelBuilder);
            AddRelationships(modelBuilder);
        }

        private void AddIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concept>()
                .HasIndex(e => new { e.NameId, e.SchemaId }).IsUnique();
            modelBuilder.Entity<ConceptManyRequired>()
                .HasIndex(e => new { e.Concept1Id, e.Concept2Id }).IsUnique();
            modelBuilder.Entity<ConceptOneRequired>()
                .HasIndex(e => new { e.Concept1Id, e.Concept2Id }).IsUnique();
            modelBuilder.Entity<ConceptManyOptional>()
                .HasIndex(e => new { e.Concept1Id, e.Concept2Id }).IsUnique();
            modelBuilder.Entity<ConceptOneOptional>()
                .HasIndex(e => new { e.Concept1Id, e.Concept2Id }).IsUnique();
            modelBuilder.Entity<Domain>()
                .HasIndex(e => new { e.NameId, e.SystemId }).IsUnique();
            modelBuilder.Entity<Schema>()
                .HasIndex(e => new { e.DomainId, e.NameId }).IsUnique();
            modelBuilder.Entity<System>()
                .HasIndex(e => new { e.NameId }).IsUnique();
        }

        private void AddRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConceptManyRequired>()
                .HasOne(e => e.Concept1)
                .WithMany(e => e.ManyRequiredLeft)
                .HasForeignKey(e => e.Concept1Id);
            modelBuilder.Entity<ConceptManyRequired>()
                .HasOne(e => e.Concept2)
                .WithMany(e => e.ManyRequiredRight)
                .HasForeignKey(e => e.Concept2Id);
            modelBuilder.Entity<ConceptOneRequired>()
                .HasOne(e => e.Concept1)
                .WithMany(e => e.OneRequiredLeft)
                .HasForeignKey(e => e.Concept1Id);
            modelBuilder.Entity<ConceptOneRequired>()
                .HasOne(e => e.Concept2)
                .WithMany(e => e.OneRequiredRight)
                .HasForeignKey(e => e.Concept2Id);
            modelBuilder.Entity<ConceptManyOptional>()
                .HasOne(e => e.Concept1)
                .WithMany(e => e.ManyOptionalLeft)
                .HasForeignKey(e => e.Concept1Id);
            modelBuilder.Entity<ConceptManyOptional>()
                .HasOne(e => e.Concept2)
                .WithMany(e => e.ManyOptionalRight)
                .HasForeignKey(e => e.Concept2Id);
            modelBuilder.Entity<ConceptOneOptional>()
                .HasOne(e => e.Concept1)
                .WithMany(e => e.OneOptionalLeft)
                .HasForeignKey(e => e.Concept1Id);
            modelBuilder.Entity<ConceptOneOptional>()
                .HasOne(e => e.Concept2)
                .WithMany(e => e.OneOptionalRight)
                .HasForeignKey(e => e.Concept2Id);
        }
    }
}
