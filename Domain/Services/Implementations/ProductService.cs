using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;

        private Shopbridge_Context Shopbridge_Context;

        public ProductService(Shopbridge_Context _Shopbridge_Context)
        {
            Shopbridge_Context = _Shopbridge_Context;
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return Shopbridge_Context.Product.ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            return Shopbridge_Context.Product.Where(x=>x.Id == id).FirstOrDefault();
        }


        public async Task<bool> PutProduct(int id, Product product)
        {
            var productExist = Shopbridge_Context.Product.Where(x => x.Id == id).FirstOrDefault();
            if(productExist!= null)
            {
                productExist.Name = product.Name;
                productExist.Description = product.Description;
                productExist.Price = product.Price;

                Shopbridge_Context.Product.Update(productExist);
                await Shopbridge_Context.SaveChangesAsync();
            }
            return true;
        }


        public async Task<Product> PostProduct(Product product)
        {
            if (product != null)
            {
                Shopbridge_Context.Product.Add(product);
                await Shopbridge_Context.SaveChangesAsync();
            }
            return product;
        }


        public async Task<bool> DeleteProduct(int id)
        {
            var productExist = Shopbridge_Context.Product.Where(x => x.Id == id).FirstOrDefault();
            if (productExist != null)
            {
                Shopbridge_Context.Product.Remove(productExist);
                await Shopbridge_Context.SaveChangesAsync();
            }
            return true;
        }


    }
}
