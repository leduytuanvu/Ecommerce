using ErrorOr;

namespace Ecommerce.Domain.Common.Errors
{
    public static class CategoryError
    {
        public static Error CreateError { get; set; } = Error.Conflict(
                code: "CREATE_CATEGORY_FAILED",
                description: "Create category failed");
    }
}
