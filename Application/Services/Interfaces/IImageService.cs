using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        string UploadImage(IFormFile file);
        void DeleteImage(string path);
    }
}
