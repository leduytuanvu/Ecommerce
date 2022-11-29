using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Shipper
    {
        public int Id { get; set; }
    
        public string CompanyName { get; set; } = string.Empty;
       
        public string Phone { get; set; } = string.Empty;
    }
}
