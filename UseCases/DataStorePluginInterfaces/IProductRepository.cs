using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(bool loadCategory = false);
        void AddProduct(Product product);
        void UpdateProduct(int productId, Product product);
        Product? GetProductById(int productId, bool loadCategory = false);
        void DeleteProduct(int productId);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}
