using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        //public List<string> Images { get; set; } = new List<string>();

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
