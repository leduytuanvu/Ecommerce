using ErrorOr;

namespace Ecommerce.Domain.Common.Errors
{
    public static class AuthenticationError
    {
        public static Error UsernameAndPasswordEmpty { get; set; } = Error.Validation(
                code: "USER_NAME_AND_PASSWORD_EMPTY",
                description: "Please enter username and password");

        public static Error PasswordWeek { get; set; } = Error.Validation(
                code: "PASSWORD_WEEK",
                description: "Password must more than 5 characters");

        public static Error DuplicateUsername { get; set; } = Error.Conflict(
                code: "DUPLICATE_USERNAME",
                description: "Username already exists");

        public static Error CheckPasswordWithRepassword { get; set; } = Error.Conflict(
                code: "PASSWORD_NOT_MATCH_RESPASSWORD",
                description: "Password and re-password not match");

        public static Error PhoneIsEmpty { get; set; } = Error.Conflict(
                code: "PHONE_IS_EMPTY",
                description: "Phone must not empty");

        public static Error EmailIsEmpty { get; set; } = Error.Conflict(
                code: "EMAIL_IS_EMPTY",
                description: "Email must not empty");

        public static Error UsernameIsEmpty { get; set; } = Error.Conflict(
                code: "USER_NAME_IS_EMPTY",
                description: "Username must have more than 5 characters");

        public static Error PasswordIsEmpty { get; set; } = Error.Conflict(
                code: "PASSWORD_IS_EMPTY",
                description: "Password must not empty");

        public static Error FullNameIsEmpty { get; set; } = Error.Conflict(
                code: "FULL_NAME_IS_EMPTY",
                description: "Full name must not empty");
        public static Error UserNameOrPasswordWrong { get; set; } = Error.Conflict(
                code: "USER_NAME_OR_PASSWORD_WRONG",
                description: "Username or password wrong");
        public static Error CreateUserFaild { get; set; } = Error.Conflict(
                code: "CREATE_USER_FAILD",
                description: "Create user faild");
        public static Error TokenGenerationFailed { get; set; } = Error.Validation(
                code: "GENERATE_TOKEN_FAILD",
                description: "Generate token faild");
    }
}
