namespace Ecommerce.Contracts.Payment.Request
{
    public class PaymentCreateRequest
    {
        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; } = DateTime.Now;
    }
}
