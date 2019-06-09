using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Services.Implementation
{
    public class ImageService : IImageService
    {
        public void DeleteImage(string path)
        {
            string rootFolder = Directory.GetCurrentDirectory();
            System.IO.File.Delete(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "/WebApp", "wwwroot/images", path));
        }
        public string UploadImage(IFormFile file)
        {
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "/WebApp", "wwwroot/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
