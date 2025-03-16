using chancelleryApp.ViewModels.Base;
using System.Windows.Input;

namespace chancelleryApp.ViewModels
{
    public class MainWindowViewModel: ViewModel
    {
        private ViewModel _CurrentVM;

        public ViewModel CurrentVM
        {
            get => _CurrentVM;
            set => Set(ref  _CurrentVM, value);
        }



        public MainWindowViewModel()
        { 
            var loginViewModel = new LoginViewModel();
            loginViewModel.RequestChangeViewModel += OnRequestChangeViewModel;
            CurrentVM = loginViewModel;
        }


        private void OnRequestChangeViewModel(object sender, ViewModel newVM) {

            if (CurrentVM != null) 
                CurrentVM.RequestChangeViewModel -= OnRequestChangeViewModel;


            newVM.RequestChangeViewModel += OnRequestChangeViewModel;

            CurrentVM = newVM;
        }
    }
}