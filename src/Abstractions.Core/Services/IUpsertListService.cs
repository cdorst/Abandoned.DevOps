using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevOps.Abstractions.Core.Services
{
    public interface IUpsertListService<TDbContext, TRecord>
        where TDbContext : DbContext
        where TRecord : class
    {
        Task<List<TRecord>> UpsertAsync(List<TRecord> records);
    }
}
