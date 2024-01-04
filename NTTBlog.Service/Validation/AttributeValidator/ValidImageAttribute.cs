using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Validation.AttributeValidator
{
    public  class ValidImageAttribute : ValidationAttribute
    {
        public int MaxFileLengthMb { get; set; }

        public override bool IsValid(object? value)
        {
            IFormFile? file = value as IFormFile;

            if (file == null)
                return true;

            if (MaxFileLengthMb > 0 && file.Length > MaxFileLengthMb * 1024 * 1024)
            {
                ErrorMessage = $"File Length greater than {MaxFileLengthMb} MB";
                return false;
            }
            else if (!file.ContentType.StartsWith("image/"))
            {
                ErrorMessage = "Invalid Image Format";
                return false;
            }

            return true;
        }
    }
}
