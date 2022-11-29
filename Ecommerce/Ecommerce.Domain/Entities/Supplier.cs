using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;
        [MaxLength(10)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;
    }
}
