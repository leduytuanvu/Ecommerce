using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; }
    }
}
