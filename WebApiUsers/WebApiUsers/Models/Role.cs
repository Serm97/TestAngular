using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsers.Models
{
    public class Role
    {

        public Role()
        {
            
        }

        public int Id{ get; set; }
        public String NameRole { get; set; }
        public bool active;


    }
}
