using chancelleryApp.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Entityes
{
    public class User: Person
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Passport { get; set; }

        public DateTime BirthDay { get; set; }

        public string BankReq { get; set; }

        public string FamilyStatus { get; set; }

        public string HealthStatus { get; set; }
    }
}
