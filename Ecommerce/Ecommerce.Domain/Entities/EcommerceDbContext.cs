using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Domain.Entities
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> option) : base(option)
        {

        }

        #region DbSet

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Image> Images { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => c.Id);
                e.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.Image).IsRequired().HasColumnType("varchar(max)");
                e.Property(c => c.Description).HasColumnType("nvarchar(500)");
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(c => c.Id);
                e.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.Property(c => c.Username).IsRequired().HasColumnType("varchar(50)");
                e.Property(c => c.Password).IsRequired().HasColumnType("varchar(max)");
                e.Property(c => c.Phone).IsRequired().HasColumnType("varchar(10)");
                e.Property(c => c.Email).IsRequired().HasColumnType("varchar(50)");
                e.Property(c => c.Avatar).HasColumnType("varchar(max)");
                e.Property(c => c.FullName).IsRequired().HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.Id);
                e.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.HasOne(o => o.User).WithMany(o => o.Orders).HasForeignKey(o => o.UserId);
                e.HasOne(o => o.Shipper).WithMany(o => o.Orders).HasForeignKey(o => o.ShipperId);
                e.HasOne(o => o.Payment).WithMany(o => o.Orders).HasForeignKey(o => o.PaymentId);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(o => o.Id);
                e.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.HasOne(o => o.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderId);
                e.HasOne(o => o.Product).WithMany(o => o.OrderDetails).HasForeignKey(o => o.ProductId);
            });

            modelBuilder.Entity<Payment>(e =>
            {
                e.ToTable("Payment");
                e.HasKey(p => p.Id);
                e.Property(o => o.Expiry).HasDefaultValueSql("getutcdate()");
                e.Property(p => p.PaymentType).HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(p => p.Id);
                e.Property(p => p.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(100)");
                e.Property(p => p.Description).HasColumnType("nvarchar(500)");
                e.HasOne(p => p.Category).WithMany(o => o.Products).HasForeignKey(o => o.CategoryId);
                e.HasOne(p => p.Supplier).WithMany(o => o.Products).HasForeignKey(o => o.SupplierId);
            });

            modelBuilder.Entity<Shipper>(e =>
            {
                e.ToTable("Shipper");
                e.HasKey(s => s.Id);
                e.Property(s => s.CompanyName).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(s => s.Phone).IsRequired().HasColumnType("varchar(10)");
                e.Property(c => c.Image).IsRequired().HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Supplier>(e =>
            {
                e.ToTable("Supplier");
                e.HasKey(s => s.Id);
                e.Property(s => s.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(s => s.Phone).IsRequired().HasColumnType("varchar(10)");
                e.Property(s => s.Address1).IsRequired().HasColumnType("nvarchar(500)");
                e.Property(s => s.Address2).HasColumnType("nvarchar(500)");
                e.Property(s => s.Email).IsRequired().HasColumnType("varchar(50)");
                e.Property(s => s.Avatar).HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Image>(e =>
            {
                e.ToTable("Image");
                e.HasKey(i => i.Id);
                e.Property(i => i.Url).IsRequired().HasColumnType("varchar(max)");
                e.Property(i => i.Alt).HasColumnType("nvarchar(50)");
                e.Property(i => i.Title).HasColumnType("nvarchar(50)");
                e.Property(i => i.Description).HasColumnType("nvarchar(500)");
            });
        }
    }
}
