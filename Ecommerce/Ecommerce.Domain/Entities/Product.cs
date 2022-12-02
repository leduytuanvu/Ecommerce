using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double Price { get; set; } = 0;

        public int Quantity { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }


        public Guid CategoryId { get; set; }

        public Guid SupplierId { get; set; }

        public Category Category { get; set; } = new Category();

        public Supplier Supplier { get; set; } = new Supplier();

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
