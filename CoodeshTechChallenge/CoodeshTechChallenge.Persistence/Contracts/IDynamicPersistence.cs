using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoodeshTechChallenge.Persistence.Contracts
{
    public interface IDynamicPersistence<D> where D : class
    {
        Task<List<D>> PostListAsync(List<D> domainList);
    }
}
