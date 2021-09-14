using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.DB
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }

    }

    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
