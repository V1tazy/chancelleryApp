using chancelleryApp.Infrastructure.Commands;
using chancelleryApp.Services.Items;
using chancelleryApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace chancelleryApp.ViewModels
{
    internal class DialogItemViewModel: ViewModel
    {

        private readonly IItemsService _itemsService;

        public ICommand AddCommand { get; }

        public DialogItemViewModel()
        {
            _itemsService = App.Services.GetService<IItemsService>();

            AddCommand = new LambdaCommand(OnAddCommandExecute, CanAddCommandExecute);
        }

        private bool CanAddCommandExecute(object arg)
        {
            throw new NotImplementedException();
        }

        private void OnAddCommandExecute(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
