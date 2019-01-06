using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.NetCore.Models
{
    public class ManagementContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=NGTRDAI197\NGTRDAI197;Database=ManagementDB;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
    }
}
