namespace pokemonblazor.Services;

public class LoginService
{
    public bool IsLogged { get; set; }
    public string Token { get; set; }

    public LoginService()
    {
        IsLogged = false;
    }
}