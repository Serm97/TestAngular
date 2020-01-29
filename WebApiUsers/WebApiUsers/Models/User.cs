using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiUsers.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public String Name { get; set; }
        public List<Role> Roles{ get; set; }
        public bool Active { get; set; }
    }
}
