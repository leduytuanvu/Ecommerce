namespace Ecommerce.Contracts.OrderDetail.Request
{
    public class OrderDetailCreateRequest
    {
        public double Total { get; set; } = 0;

        public double Discount { get; set; } = 0;

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }
    }
}
