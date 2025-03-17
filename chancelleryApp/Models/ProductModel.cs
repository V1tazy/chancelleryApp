using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chancelleryApp.Models
{
    public class ProductModel
    {
        public int Article_ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImagePath { get; set; } = @"C:\\Users\\Work\\source\\repos\\chancelleryApp\\chancelleryApp\\Image\\plug.png";
    }
}
