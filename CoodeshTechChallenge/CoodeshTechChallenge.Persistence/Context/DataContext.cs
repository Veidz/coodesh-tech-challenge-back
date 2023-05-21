using Microsoft.EntityFrameworkCore;

namespace CoodeshTechChallenge.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
