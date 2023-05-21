using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoodeshTechChallenge.Persistence.Contracts
{
    public interface IStaticPersistence<D> where D : class
    {
        Task<List<D>> GetAsync();
    }
}
