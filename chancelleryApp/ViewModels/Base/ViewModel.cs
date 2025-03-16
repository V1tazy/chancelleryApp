using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.ViewModels.Base
{
    public abstract class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if(Equals(value, field)) return false;

            field = value;

            OnPropertyChanged(PropertyName);

            return true;
        }

        public event EventHandler<ViewModel> RequestChangeViewModel;

        protected void RequestViewModelChanged(ViewModel newViewModel)
        {
            RequestChangeViewModel?.Invoke(this, newViewModel);
        }
    }
}
