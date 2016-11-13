using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inlämning2_albin_eklundh.Models;

namespace inlämning2_albin_eklundh.Controllers
{
    public class CategoryController
    {
        private readonly WebshopDbContext _dbContext;

        public CategoryController()
        {
            _dbContext = new WebshopDbContext();
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
