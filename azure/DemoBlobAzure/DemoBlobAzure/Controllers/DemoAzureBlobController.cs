using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DemoBlobAzure.Controllers;


[ApiController]
[Route("/blob")]
public class DemoAzureBlobController : ControllerBase
{
    private BlobServiceClient _blobServiceClient;
    public DemoAzureBlobController()
    {
        //Par clé
        // StorageSharedKeyCredential keyCredential = new StorageSharedKeyCredential("utopios", "f+MNepU+9I2qqVi/DvBs/t0TN18kWYK5ogsFArG1c7/DfjMO2jiXrM22BuL+AbihidNMXMt++66d+AStFSOTYw==");
        // _blobServiceClient = new BlobServiceClient(new Uri("http://utopios.blob.core.windows.net"),keyCredential);
        //_blobServiceClient = new BlobServiceClient(@"DefaultEndpointsProtocol=https;AccountName=utopios;AccountKey=f+MNepU+9I2qqVi/DvBs/t0TN18kWYK5ogsFArG1c7/DfjMO2jiXrM22BuL+AbihidNMXMt++66d+AStFSOTYw==;EndpointSuffix=core.windows.net");
        _blobServiceClient = new BlobServiceClient(new Uri("https://utopios.blob.core.windows.net"),new ManagedIdentityCredential());
    }

    //Créate container 
    [HttpPost("/container")]
    public IActionResult Post(string name)
    {
        //Créer container 
        BlobContainerClient containerClient = _blobServiceClient.CreateBlobContainer(name);
        if (containerClient.Exists())
        {
            return Ok(new { Message = "Container created " + containerClient.Name });
        }
        else
        {
            return Ok(new { message = "Erreur création" });
        }
    }
    
    //Upload
    [HttpPut("/container/{name}")]
    public IActionResult Put(string name, IFormFile image)
    {
        //Récupérer un container blob 
        BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(name);
        BlobClient blobClient = containerClient.GetBlobClient(image.FileName);
        blobClient.Upload(image.OpenReadStream());
        return Ok(new { message= "uploadOk" });
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        List<string> urls = new List<string>();
        BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(name);
        var results = containerClient.GetBlobs();
        foreach (BlobItem item in results)
        {
            urls.Add(item.Name);
        }

        return Ok(urls);
    }
}