namespace Ecommerce.Contracts.Category.Response
{
    public class CategoryResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
