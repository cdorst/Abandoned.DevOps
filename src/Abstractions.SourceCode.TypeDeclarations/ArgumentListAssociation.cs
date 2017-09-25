using DevOps.Abstractions.Core;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Abstractions.SourceCode.TypeDeclarations
{
    [ProtoContract]
    [Table("ArgumentListAssociations", Schema = nameof(SourceCode))]
    public class ArgumentListAssociation : IUniqueListAssociation<Argument>
    {
        [Key]
        [ProtoMember(1)]
        public int ArgumentListAssociationId { get; set; }

        [ProtoMember(2)]
        public Argument Argument { get; set; }
        [ProtoMember(3)]
        public int ArgumentId { get; set; }

        [ProtoMember(4)]
        public ArgumentList ArgumentList { get; set; }
        [ProtoMember(5)]
        public int ArgumentListId { get; set; }

        public Argument GetRecord() => Argument;

        public void SetRecord(Argument record)
        {
            Argument = record;
            ArgumentId = Argument.ArgumentId;
        }
    }
}
