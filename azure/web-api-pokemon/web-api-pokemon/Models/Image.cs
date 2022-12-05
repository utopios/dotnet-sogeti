using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_pokemon.Models;

[Table("image")]
public class Image
{
    private int id;
    private string url;
    
    private Pokemon pokemon;


    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Url
    {
        get => url;
        set => url = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    [ForeignKey("PokemonId")]
    public Pokemon Pokemon
    {
        get => pokemon;
        set => pokemon = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    [Column("pokemon_id")]
    public int PokemonId { get; set; }
}