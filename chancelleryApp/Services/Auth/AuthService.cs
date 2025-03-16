using chancelleryApp.DAL.Entityes;
using chancelleryApp.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _Repository;

        public AuthService(IRepository<User> repository)
        {
            _Repository = repository;
        }

        public async Task<User> AuthUser(string login, string password)
        {
            var user = await _Repository.items
                .FirstOrDefaultAsync(u => Equals(u.Login, login) && Equals(u.Password, password))
                .ConfigureAwait(false);

            return user;
        }

    }
}
