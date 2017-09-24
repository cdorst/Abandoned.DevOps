namespace DevOps.Abstractions.Core
{
    public interface IUniqueListAssociation<TRecord>
        where TRecord : class, IUniqueListRecord
    {
        TRecord GetRecord();
        void SetRecord(TRecord record);
    }
}
