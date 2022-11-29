using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Product
    {
        public int Id { get; set; }
      
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
      
        public double Price { get; set; }
      
        public int Quantity { get; set; }

        //public List<string> Images { get; set; } = new List<string>();

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
