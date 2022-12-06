namespace Ecommerce.Contracts.Product.Request
{
    public class ProductCreateRequest
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double Price { get; set; } = 0;

        public int Quantity { get; set; } = 1;
    }
}
