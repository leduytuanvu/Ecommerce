namespace Ecommerce.Contracts.Shipper.Response
{
    public class ShipperResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CompanyName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
