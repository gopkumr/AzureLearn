using Microsoft.EntityFrameworkCore;
using RedisCache.Models;

namespace RedisCache.DB
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
