using chancelleryApp.ViewModels.Base;

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

        }
    }
}