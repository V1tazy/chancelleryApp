using chancelleryApp.DAL.Entityes;
using chancelleryApp.Interface;
using chancelleryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chancelleryApp.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Item> _repository;

        public ProductService(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductModel>> GetAllList()
        {
            var items = await _repository.items
                .AsNoTracking()
                .Include(i => i.category)
                .Include(i => i.subCategory)
                .Include(i => i.subCategoryItem)
                .Include(i => i.describe)
                .ToListAsync();

            // Преобразуем Item в ProductModel
            var products = items.Select(item => new ProductModel
            {
                Article_ID = item.Article_id,
                Title = item.subCategoryItem?.Name ?? "Нет названия",
                Description = item.describe?.Name ?? "Нет описания",
                Price = item.coast,
                ImagePath = @"C:\Users\Work\source\repos\chancelleryApp\chancelleryApp\Image\plug.png"
            }).ToList();

            return products;
        }
    }
}