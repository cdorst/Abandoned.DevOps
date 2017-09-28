using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("ProjectFiles", Schema = nameof(SourceCode))]
    public class ProjectFile
    {
        public ProjectFile() { }
        public ProjectFile(Project project,
            string fileContent,
            string fileName,
            string pathRelativeToProject)
        {
            var path = Path.Combine(project.PathRelativeToSolution.Value, pathRelativeToProject);
            File = new File
            {
                FileContent = new FileContent(fileContent),
                Name = new AsciiStringReference(fileName),
                Path = new AsciiStringReference(path)
            };
            Project = project;
        }

        [Key]
        [ProtoMember(1)]
        public int ProjectFileId { get; set; }

        [ProtoMember(2)]
        public File File { get; set; }
        [ProtoMember(3)]
        public int FileId { get; set; }

        [ProtoMember(4)]
        public Project Project { get; set; }
        [ProtoMember(5)]
        public int ProjectId { get; set; }
    }
}
