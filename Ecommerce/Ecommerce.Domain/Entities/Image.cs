namespace Ecommerce.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Url { get; set; } = string.Empty;

        public string? Alt { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; } = new Product();
    }
}
