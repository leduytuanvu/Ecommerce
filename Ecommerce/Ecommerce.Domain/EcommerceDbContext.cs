using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.EcommerceContext
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> option) : base(option)
        {

        }


        #region DbSet

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<Shipper>? Shippers { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }

        #endregion
    }
}
