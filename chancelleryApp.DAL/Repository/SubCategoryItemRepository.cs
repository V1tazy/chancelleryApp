﻿using chancelleryApp.DAL.Context;
using chancelleryApp.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Repository
{
    internal class SubCategoryItemRepository : DbRepository<SubCategoryItem>
    {
        public SubCategoryItemRepository(chancelleryContext db) : base(db)
        {
        }
    }
}
