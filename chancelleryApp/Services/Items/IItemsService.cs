using chancelleryApp.DAL.Entityes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chancelleryApp.Services.Items
{
    internal interface IItemsService
    {
        Task<IEnumerable<Item>> GetAllList();
        void Remove(int id);

        void Add(Item item);


    }
}