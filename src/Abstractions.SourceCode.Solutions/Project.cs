using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("Projects", Schema = nameof(SourceCode))]
    public class Project
    {
        [Key]
        [ProtoMember(1)]
        public int ProjectId { get; set; }

        [ProtoMember(2)]
        public Guid? Guid { get; set; }

        [ProtoMember(3)]
        public AsciiStringReference AssemblyName { get; set; }
        [ProtoMember(4)]
        public int AssemblyNameId { get; set; }

        [ProtoMember(5)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(6)]
        public int NameId { get; set; }

        [ProtoMember(7)]
        public PackageOptions PackageOptions { get; set; }
        [ProtoMember(8)]
        public int? PackageOptionsId { get; set; }

        [ProtoMember(9)]
        public PackageReferenceList PackageReferenceList { get; set; }
        [ProtoMember(10)]
        public int? PackageReferenceListId { get; set; }

        [ProtoMember(11)]
        public AsciiStringReference PathRelativeToSolution { get; set; }
        [ProtoMember(12)]
        public int PathRelativeToSolutionId { get; set; }

        [ProtoMember(13)]
        public ProjectReferenceList ProjectReferenceList { get; set; }
        [ProtoMember(14)]
        public int? ProjectReferenceListId { get; set; }

        [ProtoMember(15)]
        public AsciiStringReference RootNamespace { get; set; }
        [ProtoMember(16)]
        public int RootNamespaceId { get; set; }

        [ProtoMember(17)]
        public SolutionFolder SolutionFolder { get; set; }
        [ProtoMember(18)]
        public int SolutionFolderId { get; set; }

        [ProtoMember(19)]
        public TargetFramework TargetFramework { get; set; }
        [ProtoMember(20)]
        public int TargetFrameworkId { get; set; }

        [ProtoMember(21)]
        public List<ProjectFile> ProjectFiles { get; set; }

        public StringBuilder GetCsprojBuilder()
        {
            var builder = new StringBuilder("<Project Sdk=\"Microsoft.NET.Sdk\">")
                .AppendLine()
                .AppendLine("  <PropertyGroup>")
                .AppendLine($"    <TargetFramework>{TargetFramework.GetName()}</TargetFramework>")
                .AppendLine($"    <AssemblyName>{AssemblyName.Value}</AssemblyName>")
                .AppendLine($"    <RootNamespace>{RootNamespace.Value}</RootNamespace>");
            if (PackageOptions != null) builder
                .AppendLine(PackageOptions.GetPackageOptions());
            builder.AppendLine("  </PropertyGroup>");
            if (PackageReferenceList != null) builder
                .AppendLine()
                .AppendLine("  <ItemGroup>")
                .AppendLine(PackageReferenceList.GetPackageReferences())
                .AppendLine("  </ItemGroup>");
            if (ProjectReferenceList != null) builder
                .AppendLine()
                .AppendLine("  <ItemGroup>")
                .AppendLine(ProjectReferenceList.GetProjectReferences())
                .AppendLine("  </ItemGroup>");
            return builder
                .AppendLine()
                .AppendLine("</Project>")
                .AppendLine();
        }

        public string GetSlnProjectConfigurationPlatforms()
            => SlnDeclarations.GetGlobalProjectConfigurationPlatforms(Guid.Value);

        public string GetSlnProjectDeclaration()
            => SlnDeclarations.GetProjectDeclaration(SlnGuidTypes.Project,
                name: Name.Value,
                path: GetSlnProjectDeclarationPath(),
                guid: Guid.Value);

        public string GetCsprojFileName() => $"{Name.Value}.csproj";

        public string GetNamespace() => RootNamespace.Value;

        private string GetSlnProjectDeclarationPath()
        {
            var path = PathRelativeToSolution.Value;
            var fileName = GetCsprojFileName();
            if (!path.EndsWith(fileName)) path = Path.Combine(path, fileName);
            return path;
        }
    }
}
