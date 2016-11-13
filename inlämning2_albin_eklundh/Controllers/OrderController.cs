using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inlämning2_albin_eklundh.Models;

namespace inlämning2_albin_eklundh.Controllers
{
    public class OrderController
    {
        private readonly WebshopDbContext _dbContext;

        public OrderController()
        {
            _dbContext = new WebshopDbContext();
        }

        //public ICollection<> GetSalesReport()
        //{
              //todo add method
        //}
    }
}
