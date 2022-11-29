using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Payment
    {
        public int Id { get; set; }
      
        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; }
    }
}
