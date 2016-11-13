using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using inlämning2_albin_eklundh.Models;

namespace inlämning2_albin_eklundh
{
    internal class WebshopDbInitializer : DropCreateDatabaseAlways<WebshopDbContext>
    {
        protected override void Seed(WebshopDbContext context)
        {
            context.Categories.AddOrUpdate(x => x.CategoryID,
                new Category { Name = "Trousers" },
                new Category { Name = "Hat" },
                new Category { Name = "Shirt" });
            context.SaveChanges();

            context.Products.AddOrUpdate(x => x.ProductID,
                new Product { Name = "Fab-lookin' trousers", CategoryID = 1, Brand = "ComfyWear", Size = "32/32", Price = 300 },
            new Product { Name = "Impressive legwear", CategoryID = 1, Brand = "ComfyWear", Size = "32/32", Price = 300 },
                new Product { Name = "Incredible hat", CategoryID = 2, Brand = "AirResist", Size = "OneSize", Price = 120 },
                new Product { Name = "Sideways-hat, with glue", CategoryID = 2, Brand = "StyleStamp", Size = "OneSize", Price = 290 },
                new Product { Name = "Shirt of ages", CategoryID = 3, Brand = "StunYourPeers", Size = "L", Price = 400 },
                new Product { Name = "A very green shirt", CategoryID = 3, Brand = "ComfyWear", Size = "M", Price = 280 },
                new Product { Name = "A moderately brown shirt", CategoryID = 3, Brand = "StyleStamp", Size = "M", Price = 430 } );
            context.SaveChanges();

            context.Customers.AddOrUpdate(x => x.CustomerID,
                new Customer { Name = "Bob Bobson", Email = "bobb@quickletter.com" },
                new Customer { Name = "Jane Hampshire", Email = "justpickles@bluesinc.com" },
                new Customer { Name = "Cissi Hoppsvans", Email = "cissi.hoppsvans@tmail.com" } );
            context.SaveChanges();

            context.Orders.AddOrUpdate(x => x.OrderID,
                new Order { CustomerID = 1, OrderPlaced = new DateTime(2016, 01, 01, 12, 00, 00) },
                new Order { CustomerID = 2, OrderPlaced = new DateTime(2016, 01, 05, 12, 00, 00) },
                new Order { CustomerID = 3, OrderPlaced = new DateTime(2016, 01, 29, 12, 00, 00) },
                new Order { CustomerID = 3, OrderPlaced = new DateTime(2016, 02, 02, 12, 00, 00) });
            context.SaveChanges();

            context.ProductOrders.AddOrUpdate(x => new { x.ProductID, x.OrderID },
                new ProductOrder { ProductID = 1, OrderID = 1, Quantity = 2 },
                new ProductOrder { ProductID = 2, OrderID = 1, Quantity = 1 },
                new ProductOrder { ProductID = 3, OrderID = 2, Quantity = 2 },
                new ProductOrder { ProductID = 4, OrderID = 2, Quantity = 4 },
                new ProductOrder { ProductID = 5, OrderID = 2, Quantity = 5 },
                new ProductOrder { ProductID = 6, OrderID = 3, Quantity = 3 },
                new ProductOrder { ProductID = 7, OrderID = 3, Quantity = 4 },
                new ProductOrder { ProductID = 2, OrderID = 3, Quantity = 1 },
                new ProductOrder { ProductID = 3, OrderID = 4, Quantity = 1 },
                new ProductOrder { ProductID = 4, OrderID = 4, Quantity = 1 },
                new ProductOrder { ProductID = 5, OrderID = 4, Quantity = 3 } );
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}
