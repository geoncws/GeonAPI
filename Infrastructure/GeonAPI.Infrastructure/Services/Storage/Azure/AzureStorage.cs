using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GeonAPI.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace GeonAPI.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteAsync(string fileName, string container)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string container)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string container, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == container);
        }

        public async Task UploadAsync(string container, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            foreach (IFormFile file in files)
            {
                BlobClient blobClient = _blobContainerClient.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                await blobClient.UploadAsync(file.OpenReadStream());
            }
        }
    }
}