using Esatto_Recruitment_WinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Interfaces
{
    public interface IProductService
    {
        public Product? GetProductById(int id);
        public void Add(Product entity);
        public void Remove(int id);
        public void Update(Product entity);
        public IEnumerable<Product> ListPaged(FilterOptions filterOptions);
    }
}
