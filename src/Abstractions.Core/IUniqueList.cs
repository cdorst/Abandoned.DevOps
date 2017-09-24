using System.Collections.Generic;

namespace DevOps.Abstractions.Core
{
    public interface IUniqueList<TRecord, TRecordListAssociation>
        where TRecord : class, IUniqueListRecord
        where TRecordListAssociation : IUniqueListAssociation<TRecord>
    {
        List<TRecordListAssociation> GetAssociations();
        void SetRecords(List<TRecord> records);
    }
}
