using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PetsShopContext _petsShopContext;

        public ProductRepository(PetsShopContext petsShopContext)
        {
            _petsShopContext = petsShopContext;
        }
        public async Task<List<Product>> getProducts()
        {
            List<Product> products = await _petsShopContext.Products.ToListAsync<Product>();
            return products;
        }
        //public async Task<List<Category>> getUserById(int[] ids)
        //{
        //    List<Category> categories = await _petsShopContext.Categories.Where(category=> category.CategoryId   ids);
        //    return categories;

        //}
    }
}
