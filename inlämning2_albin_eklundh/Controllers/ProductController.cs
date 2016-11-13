using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using inlämning2_albin_eklundh.Models;

namespace inlämning2_albin_eklundh.Controllers
{
    public class ProductController
    {
        private readonly WebshopDbContext _dbContext;

        public ProductController()
        {
            _dbContext = new WebshopDbContext();
        }


        public List<ValidationResult> Create(Product product)
        {
            ValidationContext context = new ValidationContext(product, null, null);
            List<ValidationResult> result = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(product, context, result);

            if (valid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return result;
            }
            else
            {
                return result;
            }

        }

        public Product Read(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.ProductID == id);
        }

        public List<ValidationResult> Update(Product product)
        {
            ValidationContext context = new ValidationContext(product, null, null);
            List<ValidationResult> result = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(product, context, result);

            if (valid)
            {
                var productRef = _dbContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                productRef.Name = product.Name;
                productRef.Price = product.Price;
                productRef.Brand = product.Brand;
                productRef.CategoryID = product.CategoryID;
                productRef.Size = product.Size;


                _dbContext.SaveChanges();

                return result;
            }
            else
            {
                return result;
            }
        }

        public bool Delete(Product product)
        {
            try
            {
                var prodRef = _dbContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                _dbContext.Products.Remove(prodRef);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts(Category category = null)
        {
            if (category == null)
            {
                return _dbContext.Products.OrderBy(x => x.Name).ToList();
            }
            else
            {
                return _dbContext.Products.Where(x => x.CategoryID == category.CategoryID).OrderBy(x => x.Name).ToList();
            }
        }
    }
}
