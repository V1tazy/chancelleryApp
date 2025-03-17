using chancelleryApp.DAL.Entityes;
using chancelleryApp.Models;

namespace chancelleryApp.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllList();
    }
}