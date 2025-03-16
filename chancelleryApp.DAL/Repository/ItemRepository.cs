using chancelleryApp.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Repository
{
    internal class ItemRepository: DbRepository<Item>
    {
        public override IQueryable<Item> items => base.items
            .Include(c => c.category)
            .Include(sc => sc.subCategory)
            .Include(sci => sci.subCategoryItem)
            .Include(itemdesc => itemdesc.describe);
    }
}
