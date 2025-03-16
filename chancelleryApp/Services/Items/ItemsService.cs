using chancelleryApp.DAL.Entityes;
using chancelleryApp.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chancelleryApp.Services.Items
{
    public class ItemsService : IItemsService
    {
        private readonly IRepository<Item> _repository;

        public ItemsService(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public void Add(Item item)
        {
            _repository.Add(item);
        }

        public async Task<IEnumerable<Item>> GetAllList()
        {

            return await _repository.items
                .AsNoTracking()
                .Include(i => i.category)
                .Include(i => i.subCategory)
                .Include(i => i.subCategoryItem)
                .Include(i => i.describe)
                .ToListAsync();
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}