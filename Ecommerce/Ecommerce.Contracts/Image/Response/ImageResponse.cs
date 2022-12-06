namespace Ecommerce.Contracts.Image.Response
{
    public class ImageResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Url { get; set; } = string.Empty;

        public string? Alt { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
