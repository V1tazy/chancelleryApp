using chancelleryApp.DAL.Entityes;
using chancelleryApp.Infrastructure.Commands;
using chancelleryApp.Models;
using chancelleryApp.Services.Items;
using chancelleryApp.Services.Product;
using chancelleryApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand UndoCommand { get; }

        public ProductViewModel(User currentUser)
        {
            UndoCommand = new LambdaCommand(ExecuteCommand);
            _productService = App.Services.GetService<IProductService>();
            LoadProductsAsync();
        }

        private void ExecuteCommand(object obj)
        {
            RequestViewModelChanged(new MainViewModel(CurrentUser));
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetAllList();
            Products = new ObservableCollection<ProductModel>(products);
        }
    }
}