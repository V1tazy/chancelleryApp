using chancelleryApp.DAL.Entityes;
using chancelleryApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.ViewModels
{
    internal class ProductViewModel : ViewModel
    {
        private User _CurrentUser;

        public User CurrentUser
        { 
            get => _CurrentUser;
            set => Set(ref _CurrentUser, value);
        }



        public ProductViewModel(User user)
        {
            CurrentUser = user;
        }
    }
}
