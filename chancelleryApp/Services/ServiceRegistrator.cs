using chancelleryApp.Services.Auth;
using chancelleryApp.Services.Items;
using chancelleryApp.Services.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddService(this IServiceCollection services) => services
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IItemsService, ItemsService>()
            .AddTransient<IProductService, ProductService>()
            ;
    }
}
