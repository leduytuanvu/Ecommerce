using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Contracts.Authentication.Response
{
    public class RegisterResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string? Avatar { get; set; }

        public string Token { get; set; }
    }
}
