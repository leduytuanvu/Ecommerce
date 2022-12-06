namespace Ecommerce.Application.Common.Interfaces.Services.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
