using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{

    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PaymentType { get; set; } = string.Empty;

        public DateTime Expiry { get; set; } = DateTime.Now;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
