using Microsoft.EntityFrameworkCore;
using web_api_pokemon.Models;

namespace web_api_pokemon.Tools;

public class DataBaseContext : DbContext
{
    public DbSet<RoleApp> Roles { get; set; }
    public DbSet<UserApp> Users { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=tcp:utopios-m2i.database.windows.net,1433;Initial Catalog=pokemon_ihab;Persist Security Info=False;User ID=m2iformation;Password=Toto.Tata12/;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}