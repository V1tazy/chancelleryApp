using chancelleryApp.DAL.Entityes;
using chancelleryApp.Infrastructure.Commands;
using chancelleryApp.Services.Items;
using chancelleryApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace chancelleryApp.ViewModels
{
    internal class ItemViewModel : ViewModel
    {
        private readonly IItemsService _itemsService;

        private User _CurrentUser;

        public User CurrentUser
        {
            get => _CurrentUser;
            set => Set(ref _CurrentUser, value);
        }

        private IEnumerable<Item> _CurrentContext;

        public IEnumerable<Item> CurrentContext
        {
            get => _CurrentContext;
            set => Set(ref _CurrentContext, value);
        }

        private Item _SelectedItem;

        public Item SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        public ICommand UpdateCommand { get; }
        public ICommand RemoveCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand UndoCommand { get; }

        public ItemViewModel(User currentUser)
        {
            _itemsService = App.Services.GetService<IItemsService>();
            CurrentUser = currentUser;

            AddCommand = new LambdaCommand(OnAddCommandExecute, CanAddCommandExecute);
            UpdateCommand = new LambdaCommand(OnUpdateCommandExecute);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecute, CanRemoveCommandExecute);
            EditCommand = new LambdaCommand(OnEditCommandExecute, CanEditCommandExecute);
            UndoCommand = new LambdaCommand(OnUndoCommandExecute);

            LoadDataAsync();
        }

        private void OnUndoCommandExecute(object obj)
        {
            RequestViewModelChanged(new MainViewModel(CurrentUser));
        }

        private bool CanEditCommandExecute(object arg)
        {
            if (SelectedItem != null) return true;

            return false;
        }

        private void OnEditCommandExecute(object obj)
        {
            RequestViewModelChanged(new DialogItemViewModel(CurrentUser, SelectedItem, _itemsService));
        }

        private bool CanRemoveCommandExecute(object arg)
        {
            if (SelectedItem != null) return true;

            return false;
        }

        private void OnRemoveCommandExecute(object obj)
        {
            _itemsService.Remove(SelectedItem.Id);

            SelectedItem = null;

            LoadDataAsync();
        }

        private void OnUpdateCommandExecute(object obj)
        {
            LoadDataAsync();
        }

        private bool CanAddCommandExecute(object arg)
        {
            return true;
        }

        private void OnAddCommandExecute(object obj)
        {
            RequestViewModelChanged(new DialogItemViewModel(CurrentUser, _itemsService));
        }

        private async Task LoadDataAsync()
        {
            CurrentContext = await _itemsService.GetAllList();
        }
    }
}