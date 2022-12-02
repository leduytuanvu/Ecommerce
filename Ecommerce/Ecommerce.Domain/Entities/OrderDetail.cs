using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public double Total { get; set; } = 0;

        public double Discount { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }


        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Order Order { get; set; } = new Order();

        public Product Product { get; set; } = new Product();
    }
}
