using chancelleryApp.Infrastructure.Commands;
using chancelleryApp.Services.Auth;
using chancelleryApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chancelleryApp.ViewModels
{
    internal class LoginViewModel: ViewModel
    {
        private readonly IAuthService _authService;

        public LambdaCommand LoginCommand { get; }

        private string _login;

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public LoginViewModel()
        {
            _authService = App.Services.GetService<IAuthService>();

            LoginCommand = new LambdaCommand(OnLogin, CanLogin);
        }

        private bool CanLogin(object arg)
        {
            if(Login != null && Password != null)
                return true;

            return false;
        }

        private async void OnLogin(object obj)
        {
            var user = await _authService.AuthUser(Login, Password);

            if (user != null)
            {
                RequestViewModelChanged(new MainViewModel(user));
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }
    }
}
