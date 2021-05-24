using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Rema1000API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task<bool> PutProduct(int id, Product product);

        Task<Product> PostProduct(Product product);

        Task DeleteProduct(int id);

        bool ProductExists(int id);
    }
}