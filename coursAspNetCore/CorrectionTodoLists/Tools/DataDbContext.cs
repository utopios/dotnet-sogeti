using CorrectionTodoLists.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorrectionTodoLists.Tools
{
    public class DataDbContext : DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\cours-dotnet-sogeti;Integrated Security=True");
        }
    }
}
