using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("TypeDeclarations", Schema = nameof(SourceCode))]
    public class TypeDeclaration
    {
        [Key]
        [ProtoMember(1)]
        public int TypeDeclarationId { get; set; }

        [ProtoMember(2)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(3)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(4)]
        public BaseList BaseList { get; set; }
        [ProtoMember(5)]
        public int? BaseListId { get; set; }

        [ProtoMember(6)]
        public ConstraintClauseList ConstraintClauseList { get; set; }
        [ProtoMember(7)]
        public int ConstraintClauseListId { get; set; }

        [ProtoMember(8)]
        public ConstructorList ConstructorList { get; set; }
        [ProtoMember(9)]
        public int? ConstructorListId { get; set; }

        [ProtoMember(10)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(11)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(12)]
        public Identifier Identifier { get; set; }
        [ProtoMember(13)]
        public int IdentifierId { get; set; }

        [ProtoMember(14)]
        public MethodList MethodList { get; set; }
        [ProtoMember(15)]
        public int? MethodListId { get; set; }

        [ProtoMember(16)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(17)]
        public int? ModifierListId { get; set; }

        [ProtoMember(18)]
        public Namespace Namespace { get; set; }
        [ProtoMember(19)]
        public int NamespaceId { get; set; }

        [ProtoMember(20)]
        public PropertyList PropertyList { get; set; }
        [ProtoMember(21)]
        public int? PropertyListId { get; set; }

        [ProtoMember(22)]
        public TypeParameterList TypeParameterList { get; set; }
        [ProtoMember(23)]
        public int? TypeParameterListId { get; set; }

        [ProtoMember(24)]
        public UsingDirectiveList UsingDirectiveList { get; set; }
        [ProtoMember(25)]
        public int? UsingDirectiveListId { get; set; }

        [ProtoMember(26)]
        public FieldList FieldList { get; set; }
        [ProtoMember(27)]
        public int? FieldListId { get; set; }

        public CompilationUnitSyntax GetCompilationUnitSyntax()
        {
            var compilationUnit = CompilationUnit();
            if (UsingDirectiveList != null)
            {
                compilationUnit = compilationUnit.WithUsings(
                    UsingDirectiveList.GetUsingDirectiveListSyntax());
            }
            return compilationUnit.WithMembers(
                SingletonList<MemberDeclarationSyntax>(
                    Namespace.GetNamespaceDeclaration(
                        GetTypeDeclarationSyntax())));
        }

        protected virtual BaseTypeDeclarationSyntax GetTypeDeclarationSyntax()
            => default(BaseTypeDeclarationSyntax);
    }
}
