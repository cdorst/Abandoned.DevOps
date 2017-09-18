using DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Abstractions.SourceCode.VueJs.EntityFramework
{
    public class SourceCodeVueJsDbContext : SourceCodeTypeDeclarationsDbContext
    {
        public SourceCodeVueJsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CheckboxList> CheckboxLists { get; set; }
        public DbSet<CheckboxListItem> CheckboxListItems { get; set; }
        public DbSet<Fieldset> Fieldsets { get; set; }
        public DbSet<FieldsetFormGroupAssociation> FieldsetFormGroupAssociations { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormFieldsetAssociation> FormFieldsetAssociations { get; set; }
        public DbSet<FormGroup> FormGroups { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<RadioList> RadioLists { get; set; }
        public DbSet<RadioListItem>  RadioListItems { get; set; }
        public DbSet<SelectInput> SelectInputs { get; set; }
        public DbSet<Validation> Validations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddIndexes(modelBuilder);
        }

        private void AddIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckboxListItem>()
                .HasIndex(e => new { e.CheckboxListId, e.IdentifierId }).IsUnique();
            modelBuilder.Entity<FieldsetFormGroupAssociation>()
                .HasIndex(e => new { e.FieldsetId, e.FormGroupId }).IsUnique();
            modelBuilder.Entity<FormFieldsetAssociation>()
                .HasIndex(e => new { e.FieldsetId, e.FormId }).IsUnique();
            modelBuilder.Entity<RadioListItem>()
                .HasIndex(e => new { e.RadioListId, e.IdentifierId }).IsUnique();
            modelBuilder.Entity<Validation>()
                .HasIndex(e => new { e.Required, e.MinLength, e.MaxLength, e.MinValue, e.MaxValue, e.Number, e.RegexErrorMessageId, e.RegexPatternId }).IsUnique();
        }
    }
}
