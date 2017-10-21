using DevOps.Abstractions.Core;
using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions.MarkdownFiles
{
    [ProtoContract]
    [Table("NuGetFeeds", Schema = nameof(SourceCode))]
    public class NuGetFeed : IUniqueListRecord
    {
        [Key]
        [ProtoMember(1)]
        public int NuGetFeedId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Key { get; set; }
        [ProtoMember(3)]
        public int KeyId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Value { get; set; }
        [ProtoMember(5)]
        public int ValueId { get; set; }

        public string GetNuGetFeed()
            => $"    <add key=\"{Key.Value}\" value=\"{Value.Value}\" />";
    }
}
