namespace Ecommerce.Contracts.Order.Request
{
    public class OrderCreateRequest
    {
        public int Quantity { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public Guid UserId { get; set; }

        public Guid ShipperId { get; set; }

        public Guid PaymentId { get; set; }
    }
}
