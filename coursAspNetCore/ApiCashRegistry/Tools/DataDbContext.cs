using ApiCashRegistry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCashRegistry.Tools
{
    public class DataDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CashRegistryUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source="+Environment.GetEnvironmentVariable("HOST_DATABASE")+";user Id=sa;password=Toto.Tata12/;Database=master;Integrated Security=False;Connect Timeout=30");
        }
    }
}
