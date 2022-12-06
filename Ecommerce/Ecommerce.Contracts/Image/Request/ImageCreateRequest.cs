namespace Ecommerce.Contracts.Image.Request
{
    public class ImageCreateRequest
    {
        public string Url { get; set; } = string.Empty;

        public string? Alt { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Guid ProductId { get; set; }
    }
}
