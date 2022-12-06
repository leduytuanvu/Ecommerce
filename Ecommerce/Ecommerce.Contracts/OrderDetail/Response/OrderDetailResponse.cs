namespace Ecommerce.Contracts.OrderDetail.Response
{
    public class OrderDetailResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public double Total { get; set; } = 0;

        public double Discount { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
