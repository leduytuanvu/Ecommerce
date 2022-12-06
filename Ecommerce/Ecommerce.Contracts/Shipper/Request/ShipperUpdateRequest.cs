namespace Ecommerce.Contracts.Shipper.Request
{
    public class ShipperUpdateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CompanyName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
