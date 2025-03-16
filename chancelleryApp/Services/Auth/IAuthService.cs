using chancelleryApp.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.Services.Auth
{
    internal interface IAuthService
    {
        Task<User> AuthUser(string login, string password);
    }
}
