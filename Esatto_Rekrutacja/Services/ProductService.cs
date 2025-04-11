using Esatto_Recruitment_WinForms.Database;
using Esatto_Recruitment_WinForms.Interfaces;
using Esatto_Recruitment_WinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
        {
            using (var dbContext = new SQLiteDbContext())
            {
                return dbContext.Products.ToList();
            }
        }

        public Product? GetProductById(int id)
        {
            using (var dbContext = new SQLiteDbContext())
            {
                return dbContext.Products.Find(id);
            }
        }

        public void Add(Product product)
        {
            using (var dbContext = new SQLiteDbContext())
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (var dbContext = new SQLiteDbContext())
            {
                dbContext.Products.Update(product);
                dbContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var dbContext = new SQLiteDbContext())
            {
                var productToDelete = dbContext.Products.Find(id);
                if (productToDelete != null)
                {
                    dbContext.Products.Remove(productToDelete);
                    dbContext.SaveChanges();
                }
            }
        }

        public IEnumerable<Product> ListPaged(FilterOptions filterOptions)
        {
            if (filterOptions.pageNum <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filterOptions.pageNum), "Number of page must be greater than 0.");
            }
            if (filterOptions.pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filterOptions.pageSize), "Page size must be greater than 0.");
            }

            using (var dbContext = new SQLiteDbContext())
            {
                if(filterOptions.searchedName == string.Empty)
                {
                    return dbContext.Products
                        .Skip((filterOptions.pageNum - 1) * filterOptions.pageSize)
                        .Take(filterOptions.pageSize)
                        .ToList();
                }
                else
                {
                    return dbContext.Products
                        .Where(p => p.Name.Contains(filterOptions.searchedName))
                        .Skip((filterOptions.pageNum - 1) * filterOptions.pageSize)
                        .Take(filterOptions.pageSize)
                        .ToList();
                }
            }
        }
    }
}
