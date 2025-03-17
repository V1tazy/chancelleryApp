using chancelleryApp.DAL.Entityes;
using chancelleryApp.Models;
using chancelleryApp.Services.Items;
using chancelleryApp.Services.Product;
using chancelleryApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace chancelleryApp.ViewModels
{
    internal class ProductViewModel : ViewModel
    {
        private readonly IProductService _productService;
        private ObservableCollection<ProductModel> _products;

        private User _CurrentUser;

        public User CurrentUser
        {
            get => _CurrentUser;
            set => Set(ref _CurrentUser, value);
        }

        public ObservableCollection<ProductModel> Products
        {
            get => _products;
            set => Set(ref _products, value);
        }

        public ProductViewModel(User currentUser)
        {
            _productService = App.Services.GetService<IProductService>();
            LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetAllList();
            Products = new ObservableCollection<ProductModel>(products);
        }
    }
}