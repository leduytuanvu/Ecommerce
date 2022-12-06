namespace Ecommerce.Contracts.Product.Response
{
    public class ProductResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double Price { get; set; } = 0;

        public int Quantity { get; set; } = 1;
    }
}
