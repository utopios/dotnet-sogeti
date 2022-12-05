using System.Reflection.Metadata;
using Azure.Storage.Blobs;
using web_api_pokemon.Services.Interfaces;

namespace web_api_pokemon.Services;

public class UploadService : IUpload
{
    private BlobServiceClient _blobServiceClient;
    private BlobContainerClient _blobContainerClient;

    public UploadService()
    {
        _blobServiceClient = new BlobServiceClient(@"DefaultEndpointsProtocol=https;AccountName=utopios;AccountKey=f+MNepU+9I2qqVi/DvBs/t0TN18kWYK5ogsFArG1c7/DfjMO2jiXrM22BuL+AbihidNMXMt++66d+AStFSOTYw==;EndpointSuffix=core.windows.net");
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient("blob-pokemon-ihab");
    }
    public string UploadImage(IFormFile image)
    {
        string url = "https://utopios.blob.core.windows.net/blob-pokemon-ihab/";
        string fileName = Guid.NewGuid()+ "-"+image.FileName;
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);

        try
        {
            blobClient.Upload(image.OpenReadStream());
            return url + fileName;
        }
        catch (Exception ex)
        {
             throw new Exception("Erreur upload");
        }
        
    }
}