using DevOps.Abstractions.Core;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.Solutions.MarkdownFiles
{
    [ProtoContract]
    [Table("NuGetFeedListAssociations", Schema = nameof(SourceCode))]
    public class NuGetFeedListAssociation : IUniqueListAssociation<NuGetFeed>
    {
        [Key]
        [ProtoMember(1)]
        public int NuGetFeedListAssociationId { get; set; }

        [ProtoMember(2)]
        public NuGetFeed NuGetFeed { get; set; }
        [ProtoMember(3)]
        public int NuGetFeedId { get; set; }

        [ProtoMember(4)]
        public NuGetFeedList NuGetFeedList { get; set; }
        [ProtoMember(5)]
        public int NuGetFeedListId { get; set; }

        public NuGetFeed GetRecord() => NuGetFeed;

        public void SetRecord(NuGetFeed record)
        {
            NuGetFeed = record ?? throw new ArgumentNullException(nameof(record));
            NuGetFeedId = NuGetFeed.NuGetFeedId;
        }
    }
}
