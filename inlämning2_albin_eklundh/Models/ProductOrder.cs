using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlämning2_albin_eklundh.Models
{
    public class ProductOrder
    {
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        [Key, Column(Order = 2)]
        public int OrderID { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
