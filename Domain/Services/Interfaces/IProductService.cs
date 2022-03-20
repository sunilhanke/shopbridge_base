using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductById(int id);
        Task<bool> PutProduct(int id, Product product);
        Task<Product> PostProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
