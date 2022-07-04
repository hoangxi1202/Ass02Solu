using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.DataAccess;

namespace BusinessObject.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product product) => ProductDAO.Instance.CreateProduct(product);
        

        public void DeleteProduct(int productID) => ProductDAO.Instance.DeleteProduct(productID);   

        public List<Product> GetListProducts() => ProductDAO.Instance.GetListProducts();

        public Product GetProductById(int id) => ProductDAO.Instance.GetProduct(id);

        public List<string> GetProductNames() => ProductDAO.Instance.GetProductsName();

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
