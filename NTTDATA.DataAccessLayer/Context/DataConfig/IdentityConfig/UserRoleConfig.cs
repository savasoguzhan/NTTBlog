using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTTBlog.Entity.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.DataAccessLayer.Context.DataConfig.IdentityConfig
{
    public class UserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("538FAB7B-024B-458A-BB52-B2520F3BCC49"),
                RoleId= Guid.Parse("87B47B4D-98AE-4767-B1FA-D39D2BD0E800")
            },
           new AppUserRole
           {
               UserId= Guid.Parse("0A3ADEE6-2F0D-42B7-83D3-22F95F64CCAB"),
               RoleId= Guid.Parse("CC17CF5B-4AC8-4720-9046-28B0DD47F2DE")
           });
        }
    }
}
