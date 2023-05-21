using CoodeshTechChallenge.Domain;
using CoodeshTechChallenge.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CoodeshTechChallenge.Persistence.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Type> Type { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>().HasData(
                new Type() { Id = 1, Description = "Venda produtor" },
                new Type() { Id = 2, Description = "Venda afiliado" },
                new Type() { Id = 3, Description = "Comissão paga" },
                new Type() { Id = 4, Description = "Comissão recebida" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "CURSO DE BEM-ESTAR" },
                new Product() { Id = 2, Name = "DOMINANDO INVESTIMENTOS" },
                new Product() { Id = 3, Name = "DESENVOLVEDOR FULL STACK" }
            );

            modelBuilder.Entity<Seller>().HasData(
                new Seller() { Id = 1, Name = "JOSE CARLOS" },
                new Seller() { Id = 2, Name = "MARIA CANDIDA" },
                new Seller() { Id = 3, Name = "THIAGO OLIVEIRA" },
                new Seller() { Id = 4, Name = "ELIANA NOGUEIRA" },
                new Seller() { Id = 5, Name = "CARLOS BATISTA" },
                new Seller() { Id = 6, Name = "CAROLINA MACHADO" },
                new Seller() { Id = 7, Name = "CELSO DE MELO" }
            );
        }
    }
}
