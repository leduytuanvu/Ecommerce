namespace Ecommerce.Contracts.Payment.Request
{
    public class PaymentUpdateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; } = DateTime.Now;
    }
}
