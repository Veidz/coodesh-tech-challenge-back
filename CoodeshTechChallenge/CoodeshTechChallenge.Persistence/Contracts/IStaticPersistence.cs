using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoodeshTechChallenge.Persistence.Contracts
{
    public interface IStaticPersistence<D> where D : class
    {
        Task<List<D>> GetAsync();
        Task<List<D>> GetFilterAsync(Expression<Func<D, bool>> filterExpression);
    }
}
