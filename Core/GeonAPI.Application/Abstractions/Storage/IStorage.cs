using System;
using Microsoft.AspNetCore.Http;

namespace GeonAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task UploadAsync(string pathOrContainer, IFormFileCollection files);
        Task DeleteAsync(string fileName, string pathOrContainer);
        List<string> GetFiles(string pathOrContainer);
        bool HasFile(string pathOrContainer, string fileName);
    }
}