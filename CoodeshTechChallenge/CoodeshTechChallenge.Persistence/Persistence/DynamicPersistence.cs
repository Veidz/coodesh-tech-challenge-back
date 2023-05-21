using CoodeshTechChallenge.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoodeshTechChallenge.Persistence.Persistence
{
    public class DynamicPersistence<D> : IDynamicPersistence<D> where D : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<D> dbSet;

        public DynamicPersistence(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext != null ? this.dbContext.Set<D>() : throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<D>> PostListAsync(List<D> domainList)
        {
            if (domainList == null)
            {
                throw new ArgumentNullException(nameof(domainList));
            }
            else
            {
                foreach (D domain in domainList)
                {
                    this.dbSet.Add(domain);
                }

                await this.dbContext.SaveChangesAsync();
                return domainList;
            }
        }
    }
}
