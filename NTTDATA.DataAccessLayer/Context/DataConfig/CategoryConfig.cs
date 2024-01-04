using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTTBlog.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DataAccessLayer.Context.DataConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.HasData( new Category
            {
                Id = Guid.Parse("9B1056F6-6171-49A5-9BAA-D22C489289B6"),
                Name = "Deneme",
                CreatedDate = DateTime.Now,
                CreatedBy = "adminDeneme"

            },
            new Category
            {
                Id = Guid.Parse("E90E9E24-83D4-4B50-AE2C-D3187ABF3D26"),
                Name = "Deneme 2",
                CreatedDate = DateTime.Now,
                CreatedBy = "adminDeneme",
            });
        }
    }
}
