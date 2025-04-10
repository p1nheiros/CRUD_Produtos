using Microsoft.EntityFrameworkCore;

namespace CrudProdutos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
    }
}
