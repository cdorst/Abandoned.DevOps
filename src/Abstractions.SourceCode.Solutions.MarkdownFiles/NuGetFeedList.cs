using DevOps.Abstractions.Core;
using DevOps.Abstractions.UniqueStrings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DevOps.Abstractions.SourceCode.Solutions.MarkdownFiles
{
    [ProtoContract]
    [Table("NuGetFeedLists", Schema = nameof(SourceCode))]
    public class NuGetFeedList : IUniqueList<NuGetFeed, NuGetFeedListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int NuGetFeedListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<NuGetFeedListAssociation> NuGetFeedListAssociations { get; set; }

        public StringBuilder GetNuGetConfig()
        {
            var builder = new StringBuilder(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                .AppendLine("<configuration>")
                .AppendLine("  <packageSources>");
            foreach (var feed in NuGetFeedListAssociations.Select(f => f.NuGetFeed))
                builder.AppendLine(feed.GetNuGetFeed());
            return builder
                .AppendLine("  </packageSources>")
                .AppendLine("</configuration>");
        }

        public List<NuGetFeedListAssociation> GetAssociations() => NuGetFeedListAssociations;

        public void SetRecords(List<NuGetFeed> records)
        {
            for (int i = 0; i < NuGetFeedListAssociations.Count; i++)
            {
                NuGetFeedListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.NuGetFeedId)));
        }
    }
}
