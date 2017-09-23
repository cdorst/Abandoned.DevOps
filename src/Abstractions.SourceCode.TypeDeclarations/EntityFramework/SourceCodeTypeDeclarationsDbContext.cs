using DevOps.Abstractions.SourceCode.Solutions.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations.EntityFramework
{
    public class SourceCodeTypeDeclarationsDbContext : SourceCodeSolutionsDbContext
    {
        public SourceCodeTypeDeclarationsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Accessor> Accessors { get; set; }
        public DbSet<AccessorList> AccessorLists { get; set; }
        public DbSet<AccessorListAssociation> AccessorListAssociations { get; set; }
        public DbSet<Argument> Arguments { get; set; }
        public DbSet<ArgumentList> ArgumentLists { get; set; }
        public DbSet<ArgumentListAssociation> ArgumentListAssociations { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeArgumentListExpression> AttributeArgumentListExpressions { get; set; }
        public DbSet<AttributeListCollection> AttributeListCollections { get; set; }
        public DbSet<AttributeListCollectionAssociation> AttributeListCollectionAssociations { get; set; }
        public DbSet<BaseList> BaseLists { get; set; }
        public DbSet<BaseListAssociation> BaseListAssociations { get; set; }
        public DbSet<BaseType> BaseTypes { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
        public DbSet<ConstraintClause> ConstraintClauses { get; set; }
        public DbSet<ConstraintClauseListAssociation> ConstraintClauseListAssociations { get; set; }
        public DbSet<ConstraintList> ConstraintLists { get; set; }
        public DbSet<ConstraintListAssociation> ConstraintListAssociations { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<ConstructorBaseInitializer> ConstructorBaseInitializers { get; set; }
        public DbSet<ConstructorList> ConstructorLists { get; set; }
        public DbSet<ConstructorListAssociation> ConstructorListAssociations { get; set; }
        public DbSet<DocumentationComment> DocumentationComments { get; set; }
        public DbSet<DocumentationCommentAttribute> DocumentationCommentAttributes { get; set; }
        public DbSet<DocumentationCommentAttributeList> DocumentationCommentAttributeLists { get; set; }
        public DbSet<DocumentationCommentAttributeListAssociation> DocumentationCommentAttributeListAssociations { get; set; }
        public DbSet<DocumentationCommentList> DocumentationCommentLists { get; set; }
        public DbSet<DocumentationCommentListAssociation> DocumentationCommentListAssociations { get; set; }
        public DbSet<EnumMember> EnumMembers { get; set; }
        public DbSet<EnumMemberList> EnumMemberLists { get; set; }
        public DbSet<EnumMemberListAssociation> EnumMemberListAssociations { get; set; }
        public DbSet<Expression> Expressions { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldList> FieldLists { get; set; }
        public DbSet<FieldListAssociation> FieldListAssociations { get; set; }
        public DbSet<Finalizer> Finalizers { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<MethodList> MethodLists { get; set; }
        public DbSet<MethodListAssociation> MethodListAssociations { get; set; }
        public DbSet<ModifierList> ModifierLists { get; set; }
        public DbSet<ModifierListAssociation> ModifierListAssociations { get; set; }
        public DbSet<Namespace> Namespaces { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ParameterList> ParameterLists { get; set; }
        public DbSet<ParameterListAssociation> ParameterListAssociations { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<StatementList> StatementLists { get; set; }
        public DbSet<StatementListAssociation> StatementListAssociations { get; set; }
        public DbSet<SyntaxToken> SyntaxTokens { get; set; }
        public DbSet<TypeArgument> TypeArguments { get; set; }
        public DbSet<TypeArgumentList> TypeArgumentLists { get; set; }
        public DbSet<TypeArgumentListAssociation> TypeArgumentListAssociations { get; set; }
        public DbSet<TypeDeclaration> TypeDeclarations { get; set; }
        public DbSet<TypeParameter> TypeParameters { get; set; }
        public DbSet<TypeParameterList> TypeParameterLists { get; set; }
        public DbSet<TypeParameterListAssociation> TypeParameterListAssociations { get; set; }
        public DbSet<UsingDirective> UsingDirectives { get; set; }
        public DbSet<UsingDirectiveList> UsingDirectiveLists { get; set; }
        public DbSet<UsingDirectiveListAssociation> UsingDirectiveListAssociations { get; set; }

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
