using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_pokemon.Models;

[Table("role_app")]
public class RoleApp
{
    private int id;
    private string name;

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
}