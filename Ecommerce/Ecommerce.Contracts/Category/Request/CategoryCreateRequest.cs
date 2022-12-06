namespace Ecommerce.Contracts.Category.Request
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
