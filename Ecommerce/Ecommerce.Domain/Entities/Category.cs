using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
