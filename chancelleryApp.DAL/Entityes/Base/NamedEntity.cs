using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.DAL.Entityes.Base
{
    public class NamedEntity: Entity
    {
        [Required]

        public string Name { get; set; }
    }
}
