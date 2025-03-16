using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Entityes.Base
{
    public class Person: Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronic { get; set; }

    }
}
