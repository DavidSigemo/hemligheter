using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace inlämning2_albin_eklundh.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
