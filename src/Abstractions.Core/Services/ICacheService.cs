using System.Threading.Tasks;

namespace DevOps.Abstractions.Core.Services
{
    public interface ICacheService<TRecord>
        where TRecord : class
    {
        Task<TRecord> FindAsync(string key);
        Task RemoveAsync(string key);
        Task SaveAsync(string key, TRecord record);
    }
}
