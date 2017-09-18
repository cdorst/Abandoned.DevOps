using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DevOps.Abstractions.Core.Services
{
    public interface IUpsertService<TDbContext, TRecord> 
        where TDbContext : DbContext
        where TRecord : class 
    {
        Task<TRecord> UpsertAsync(TRecord concept);
    }
}
