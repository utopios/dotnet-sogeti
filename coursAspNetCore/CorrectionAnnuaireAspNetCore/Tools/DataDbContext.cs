using CorrectionAnnuaireAspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CorrectionAnnuaireAspNetCore.Tools
{
    public class DataDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\cours-dotnet-sogeti;Integrated Security=True");
        }
    }
}
