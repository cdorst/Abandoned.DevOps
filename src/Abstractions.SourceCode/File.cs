using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode
{
    [ProtoContract]
    [Table("Files", Schema = nameof(SourceCode))]
    public class File
    {
        [Key]
        [ProtoMember(1)]
        public int FileId { get; set; }

        [ProtoMember(2)]
        public FileContent FileContent { get; set; }
        [ProtoMember(3)]
        public int FileContentId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(5)]
        public int NameId { get; set; }

        [ProtoMember(6)]
        public AsciiStringReference Path { get; set; }
        [ProtoMember(7)]
        public int PathId { get; set; }
    }
}
