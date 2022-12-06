namespace Ecommerce.Contracts.Order.Response
{
    public class OrderResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Quantity { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
    }
}
