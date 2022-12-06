namespace Ecommerce.Contracts.Category.Request
{
    public class CategoryUpdateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? Image { get; set; } = string.Empty;

    }
}
