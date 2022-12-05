namespace web_api_pokemon.Services.Interfaces;

public interface IUpload
{
    public string UploadImage(IFormFile image);
}