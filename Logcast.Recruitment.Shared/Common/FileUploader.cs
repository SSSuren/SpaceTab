using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Shared.Common
{
    public static class FileUploader
    {
        public static async Task<string> UploadFile(IFormFile file)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Uploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fileName = $"{Guid.NewGuid()}_{file.FileName}".Replace(" ", String.Empty); ;

            string filePath = Path.Combine(path, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
