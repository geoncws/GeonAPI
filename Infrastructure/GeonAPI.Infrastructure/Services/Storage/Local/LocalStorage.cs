using System;
using System.IO;
using GeonAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
namespace GeonAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnviroment;

        public LocalStorage(IWebHostEnvironment webHostEnviroment)
        {
            _webHostEnviroment = webHostEnviroment;
        }
        public async Task DeleteAsync(string fileName, string path)
        {
            File.Delete($"{path}\\{fileName}");
            //Todo dosya fiziksel olarak dizinden silindikten sonra veritabanındaki ilgili kayıt satırıda silinecek, await ile yapılacak...
        }

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
            //Todo Bu metodta üstteki iki satıra gerek kalmayabilir, direkt veritabanından ilgili satırlardan dosya yolu ve dosya isimleri çekilecek!
        }

        public bool HasFile(string path, string fileName) => File.Exists($"{path}\\{fileName}");
        async Task<bool> CopyFileAsync(string fullPath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: true);
                var hashData = CreateFileHash(file);// todo bu fonskiyon tamamlanmadı!!! Dönen string hash data veritabanına eklenecek. 
                //todo burada multimedias tablosuna resimler kayıt edilecek. Önce resim daha önce eklenmiş mi kontrol edilmelidir.
                //todo => Burada yüklenecek dosyanın meta bilgileri hashlenerek, veritabanında varmı yok mu kontrol edilecek! Eğer varsa kayıt gerçekleşmeyecek!
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "multimedias", path);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            foreach (IFormFile file in files)
            {
                await CopyFileAsync(Path.Combine($"{uploadPath}/{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"), file);
            }
        }

    }
}