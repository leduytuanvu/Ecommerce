namespace Ecommerce.Domain.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;

        public string? Address2 { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Avatar { get; set; }

        public bool IsDeleted { get; set; } = false;


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
