using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTTBlog.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.DataAccessLayer.Context.DataConfig
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("1465691C-3690-40B6-9FAB-99A388205514"),
                Url = "image/testjpeg",
                FileType = "jpg",
                CreatedBy = "adminTest",
                CreatedDate = DateTime.Now
            },
            new Image
            {
                Id = Guid.Parse("E37A4A99-7458-4089-A6DE-D5DBF52C95CD"),
                Url = "image/test2jpeg",
                FileType = "jpg",
                CreatedBy = "adminTest",
                CreatedDate = DateTime.Now
            });
        }
    }
}
