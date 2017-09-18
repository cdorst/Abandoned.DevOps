using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions
{
    [ProtoContract]
    [Table("NuGetFeeds", Schema = nameof(SourceCode))]
    public class NuGetFeed
    {
        [Key]
        [ProtoMember(1)]
        public int NuGetFeedId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }

        [ProtoMember(4)]
        public Solution Solution { get; set; }
        [ProtoMember(5)]
        public int SolutionId { get; set; }
    }
}
