using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevOps.Abstractions.SourceCode
{
    [ProtoContract]
    [Table("FileContents", Schema = nameof(SourceCode))]
    public class FileContent
    {
        public FileContent() { DateAdded = DateTimeOffset.UtcNow; }
        public FileContent(string content) : this()
        {
            Content = new UnicodeMaxStringReference(content);
        }
        public FileContent(StringBuilder stringBuilder) : this()
        {
            Content = new UnicodeMaxStringReference(
                stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder)));
        }

        [Key]
        [ProtoMember(1)]
        public int FileContentId { get; set; }

        [ProtoMember(2)]
        public DateTimeOffset DateAdded { get; set; }

        [ProtoMember(3)]
        public UnicodeMaxStringReference Content { get; set; }
        [ProtoMember(4)]
        public int ContentId { get; set; }
    }
}
