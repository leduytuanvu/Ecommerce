﻿namespace Ecommerce.Contracts.Authentication.Requests
{
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string RePassword { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
