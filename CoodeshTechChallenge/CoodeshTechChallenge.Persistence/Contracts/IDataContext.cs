using CoodeshTechChallenge.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Type = CoodeshTechChallenge.Domain.Type;

namespace CoodeshTechChallenge.Persistence.Contracts
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<Type> Type { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Seller> Seller { get; set; }
    }
}
