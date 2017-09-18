using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode
{
    [ProtoContract]
    [Table("FileContents", Schema = nameof(SourceCode))]
    public class FileContent
    {
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
