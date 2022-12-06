namespace Ecommerce.Domain.Entities
{
    public class Shipper
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CompanyName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
