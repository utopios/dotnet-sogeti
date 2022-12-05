using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_pokemon.Models;


[Table("user_app")]
public class UserApp
{
    private int id;

    private string name;

    private string password;

    private RoleApp role;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => password;
        set => password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public RoleApp Role
    {
        get => role;
        set => role = value ?? throw new ArgumentNullException(nameof(value));
    }
    [ForeignKey("Role")]
    public int RoleAppId { get; set; }
    
    public  List<PokemonUser> Pokemons { get; set; }
}