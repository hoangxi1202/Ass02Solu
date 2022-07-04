using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.DataAccess;
using BusinessObject.Models;

namespace BusinessObject.Repository
{
    public interface IProductRepository
    {
        public Product GetProductById(int id);
        public List<string> GetProductNames();
        public List<Product> GetListProducts();
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productID);
    }
}
