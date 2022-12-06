namespace Ecommerce.Contracts.Payment.Response
{
    public class PaymentResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; } = DateTime.Now;
    }
}
