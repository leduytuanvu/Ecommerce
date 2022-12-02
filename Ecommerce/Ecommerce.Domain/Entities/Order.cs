using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Quantity { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }


        public Guid UserId { get; set; }

        public Guid ShipperId { get; set; }

        public Guid PaymentId { get; set; }

        public User User { get; set; } = new User();

        public Shipper Shipper { get; set; } = new Shipper();

        public Payment Payment { get; set; } = new Payment();

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
