using chancelleryApp.DAL;
using chancelleryApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services) => services
            .AddDbContext<chancelleryContext>(opt =>
            {
                opt.UseSqlServer("Data Source=localhost;Initial Catalog=chancelleryDb.db;Integrated Security=True;Encrypt=False");
            })
            .AddRepositoryInDB();
    }
}
