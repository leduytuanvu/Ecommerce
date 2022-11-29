using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    [Table("Shipper")]
    public class Shipper
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;
        [MaxLength(10)]
        public string Phone { get; set; } = string.Empty;
    }
}
