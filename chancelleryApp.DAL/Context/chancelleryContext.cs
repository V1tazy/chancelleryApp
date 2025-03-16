using chancelleryApp.DAL.Entityes;
using Microsoft.EntityFrameworkCore;


namespace chancelleryApp.DAL.Context
{
    public class chancelleryContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<SubCategoryItem> SubCategoriesItem { get; set; }

        public DbSet<ItemDescribe> ItemDescribe { get; set; }

        public DbSet<Item> Items { get; set; }

        public chancelleryContext(DbContextOptions<chancelleryContext> options) : base(options) { }
    }
}
