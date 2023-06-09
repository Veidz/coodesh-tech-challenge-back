﻿using CoodeshTechChallenge.Persistence.Context;
using CoodeshTechChallenge.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoodeshTechChallenge.Persistence.Persistence
{
    public class StaticPersistence<D> : IStaticPersistence<D> where D : class
    {
        private readonly IDataContext dbContext;
        private readonly DbSet<D> dbSet;

        public StaticPersistence(IDataContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext != null ? this.dbContext.Set<D>() : throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<D>> GetAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<List<D>> GetFilterAsync(Expression<Func<D, bool>> filterExpression)
        {
            return await this.dbSet.Where(filterExpression).ToListAsync();
        }
    }
}
