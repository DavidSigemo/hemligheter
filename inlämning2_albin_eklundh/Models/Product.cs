using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace inlämning2_albin_eklundh.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
