using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using inlämning2_albin_eklundh.Models;

namespace inlämning2_albin_eklundh
{
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext() : base("WebshopDbContext")
        {
            Database.SetInitializer(new WebshopDbInitializer());
            Database.Initialize(true);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
    }
}
