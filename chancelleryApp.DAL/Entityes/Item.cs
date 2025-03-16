using chancelleryApp.DAL.Entityes.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Entityes
{
    public class Item : Entity
    {
        public int Article_id { get; set; }

        public Category category { get; set; }

        public SubCategory subCategory { get; set; }
        public SubCategoryItem subCategoryItem { get; set; }

        public int coast { get; set; }

        public int quantity { get; set; }

        public ItemDescribe describe { get; set; }
    }
}
