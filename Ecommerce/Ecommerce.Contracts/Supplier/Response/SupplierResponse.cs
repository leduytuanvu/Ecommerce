namespace Ecommerce.Contracts.Supplier.Response
{
    public class SupplierResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;

        public string? Address2 { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Avatar { get; set; }
    }
}
