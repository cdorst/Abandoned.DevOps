using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevOps.Abstractions.SourceCode
{
    [ProtoContract]
    [Table("Files", Schema = nameof(SourceCode))]
    public class File
    {
        public File() { }
        public File(string name, string path, string content)
            : this(name, path)
        {
            FileContent = new FileContent(content);
        }
        public File(string name, string path, StringBuilder stringBuilder)
            : this(name, path)
        {
            FileContent = new FileContent(
                stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder)));
        }
        private File(string name, string path)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            Name = new AsciiStringReference(name);
            Path = new AsciiStringReference(path);
        }

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
