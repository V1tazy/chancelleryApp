using chancelleryApp.DAL.Entityes;
using chancelleryApp.Infrastructure.Commands;
using chancelleryApp.Services.Items;
using chancelleryApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace chancelleryApp.ViewModels
{
    internal class DialogItemViewModel: ViewModel
    {

        private readonly IItemsService _itemsService;


        private string _Content;

        public string Content
        {
            get => _Content;
            set => Set(ref _Content, value);
        }

        private User _CurrentUser;


        public User CurrentUser
        {
            get => _CurrentUser;
            set => Set(ref _CurrentUser, value);
        }

        private Item _SelectedItem;

        public Item SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        public ICommand UniversalCommand { get; }

        public ICommand CancelCommand { get; }

        public DialogItemViewModel(User currentUser, IItemsService itemsService)
        {
            _itemsService = itemsService;

            CurrentUser = currentUser;
            UniversalCommand = new LambdaCommand(OnAddCommandExecute, CanCommandExecute);

            CancelCommand = new LambdaCommand(OnCancelCommandExecute);

            Content = "Добавить";
        }

        public DialogItemViewModel(User currentUser, Item item, IItemsService itemsService)
        {
            _itemsService = itemsService;
            CurrentUser = currentUser;
            SelectedItem = item;

            Content = "Редактировать";

            UniversalCommand = new LambdaCommand(OnUpdateCommandExecute, CanCommandExecute);

            CancelCommand = new LambdaCommand (OnCancelCommandExecute);
        }

        private void OnUpdateCommandExecute(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanCommandExecute(object arg)
        {
            if(SelectedItem != null) return true;

            return false;
        }

        private void OnAddCommandExecute(object obj)
        {
            _itemsService.Add(SelectedItem);

            RequestViewModelChanged(new ItemViewModel(CurrentUser));
        }

        private void OnCancelCommandExecute(object obj)
        {
            RequestViewModelChanged(new ItemViewModel(CurrentUser));
        }
    }
}
