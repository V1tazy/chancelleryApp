using chancelleryApp.DAL.Context;
using chancelleryApp.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Repository
{
    internal class CategoryRepository: DbRepository<Category>
    {
        public CategoryRepository(chancelleryContext db) : base(db) 
        { }
    }
}
