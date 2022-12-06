using System.Text.Json;

namespace Ecommerce.Contracts.Error
{
    public class ErrorResponse
    {
        public string? StatusCode { get; set; }

        public string? Message { get; set; }

        public dynamic? Data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
