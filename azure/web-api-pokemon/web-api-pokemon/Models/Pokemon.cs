using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_pokemon.Models;

[Table("pokemon")]
public class Pokemon
{
    private int id;
    private string name;

    private List<Image> images;

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

    public List<Image> Images
    {
        get => images;
        set => images = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public List<PokemonUser> Users { get; set; }
}