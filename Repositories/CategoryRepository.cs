using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetsShopContext _petsShopContext;

        public CategoryRepository(PetsShopContext petsShopContext)
        {
            _petsShopContext = petsShopContext;
        }
        public async Task<List<Category>> getCategories()
        {
            List<Category> categories = await _petsShopContext.Categories.ToListAsync<Category>();
            return categories;
        }
        //public async Task<List<Category>> getUserById(int[] ids)
        //{
        //    List<Category> categories = await _petsShopContext.Categories.Where(category=> category.CategoryId   ids);
        //    return categories;

        //}
    }
}
