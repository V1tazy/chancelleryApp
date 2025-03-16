using chancelleryApp.DAL.Entityes;
using chancelleryApp.Infrastructure.Commands;
using chancelleryApp.Interface;
using chancelleryApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace chancelleryApp.ViewModels
{
    internal class MainViewModel: ViewModel
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }

        public ICommand ProductViewCommand { get; }
        public ICommand ItemViewCommand { get; }


        public MainViewModel(User User) 
        {
            CurrentUser = User;

            ProductViewCommand = new LambdaCommand(OnProductOpen);
            ItemViewCommand = new LambdaCommand(OnItemViewCommand);
        }

        private void OnItemViewCommand(object obj)
        {
            RequestViewModelChanged(new ItemViewModel(CurrentUser));
        }

        private void OnProductOpen(object obj)
        {
            RequestViewModelChanged(new ProductViewModel(CurrentUser));
        }
    }
}
