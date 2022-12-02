using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Shipper
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CompanyName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
