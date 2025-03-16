using chancelleryApp.DAL.Context;
using chancelleryApp.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Repository
{
    internal class ItemDescribeRepository : DbRepository<ItemDescribe>
    {
        public ItemDescribeRepository(chancelleryContext db) : base(db)
        {
        }
    }
}
