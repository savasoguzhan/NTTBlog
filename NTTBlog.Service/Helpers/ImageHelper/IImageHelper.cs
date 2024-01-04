using Microsoft.AspNetCore.Http;
using NTTBlog.Entity.Enums;
using NTTBlog.Entity.VM.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Helpers.ImageHelper
{
    public interface IImageHelper
    {
        Task<ImageUploadVM> UpLoad(string name, IFormFile imageFile ,ImageType imageType, string folderName = null);

        void Delete(string imageName);
    }
}
