namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double Price { get; set; } = 0;

        public int Quantity { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SupplierId { get; set; }

        public Category Category { get; set; } = new Category();

        public Supplier Supplier { get; set; } = new Supplier();

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
