using System;
using Microsoft.AspNetCore.Http;

namespace GeonAPI.Infrastructure.Services.Storage
{
    public class Storage
    {
        //Storage işlemleri için base class niteliğindedir.

        protected async Task<string> CreateFileHash(IFormFile file)
        {
            file.OpenReadStream().GetHashCode();
            return "";
            //todo Burada yüklenecek dosyaların meta data bilgilerinden hash data üretilecek!
        }
    }
}