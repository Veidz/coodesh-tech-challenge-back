using CoodeshTechChallenge.Domain;
using CoodeshTechChallenge.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CoodeshTechChallenge.Persistence.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Type> Type { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
