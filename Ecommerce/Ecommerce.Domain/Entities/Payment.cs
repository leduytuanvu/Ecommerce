namespace Ecommerce.Domain.Entities
{

    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
