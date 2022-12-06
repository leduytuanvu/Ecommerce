using ErrorOr;

namespace Ecommerce.Domain.Common.Errors
{
    public static class UserError
    {
        public static Error DuplicateUsername { get; set; } = Error.Conflict(
                code: "DUPLICATE_USERNAME",
                description: "Username already exists");
    }
}
