using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(10)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        //public List<string> Addresses { get; set; } = new List<string>();

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class Jwt
    {
        public string key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Subject { get; set; }
    }
}
