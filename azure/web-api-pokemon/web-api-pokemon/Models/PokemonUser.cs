using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_pokemon.Models;

[Table("pokemon_user")]
public class PokemonUser
{
    private int id;

    private Pokemon pokemon;

    private UserApp user;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public Pokemon Pokemon
    {
        get => pokemon;
        set => pokemon = value ?? throw new ArgumentNullException(nameof(value));
    }

    public UserApp User
    {
        get => user;
        set => user = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    [ForeignKey("Pokemon")]
    [Column("pokemon_id")]
    public int PokemonId { get; set; }
    
    [ForeignKey("User")]
    [Column("user_app_id")]
    public int UserAppId { get; set; }
}