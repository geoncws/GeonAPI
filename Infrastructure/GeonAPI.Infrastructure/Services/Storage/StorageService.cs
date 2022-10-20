using GeonAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace GeonAPI.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }
        //public string StorageName { get => _storage.GetType().Name; }
        public string StorageName => _storage.GetType().Name;
        public async Task DeleteAsync(string fileName, string pathOrContainer)
            => await _storage.DeleteAsync(fileName, pathOrContainer);
        public List<string> GetFiles(string pathOrContainer)
            => _storage.GetFiles(pathOrContainer);
        public bool HasFile(string pathOrContainer, string fileName)
            => _storage.HasFile(pathOrContainer, fileName);
        public async Task UploadAsync(string pathOrContainer, IFormFileCollection files)
            => await _storage.UploadAsync(pathOrContainer, files);
    }
}