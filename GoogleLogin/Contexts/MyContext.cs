using GoogleLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleLogin.Contexts
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=GoogleLoginDB;Trusted_Connection=True");
        }

        public DbSet<User> Users { get; set; }
    }
}
