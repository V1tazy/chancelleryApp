using chancelleryApp.DAL.Entityes;
using chancelleryApp.DAL.Repository;
using chancelleryApp.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoryInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<User>, UserRepository>()
            .AddTransient<IRepository<Category>, CategoryRepository>()
            .AddTransient<IRepository<SubCategory>, SubCategoryRepository>()
            .AddTransient<IRepository<SubCategoryItem>, SubCategoryItemRepository>()
            .AddTransient<IRepository<ItemDescribe>, ItemDescribeRepository>()
            .AddTransient<IRepository<Item>, ItemRepository>();
    }
}
