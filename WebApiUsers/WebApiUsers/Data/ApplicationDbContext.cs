using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsers.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiUsers.Models
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Mapping of User Model
        public DbSet<User> Users { get; set; }
    }
}

