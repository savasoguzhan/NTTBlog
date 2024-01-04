using Microsoft.AspNetCore.Identity;
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
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superAdmin =new AppUser
            {
                Id = Guid.Parse("538FAB7B-024B-458A-BB52-B2520F3BCC49"),
                UserName="masteradmin@gmail.com",
                NormalizedUserName="MASTERADMIN@GMAIL.COM",
                Email="masteradmin@gmail.com",
                NormalizedEmail="MASTERADMIN@GMAIL.COM",
                PhoneNumber="1234567890",
                Firstname ="Demo",
                LastName ="MasterAdmin",
                PhoneNumberConfirmed=false,
                EmailConfirmed=false,
                SecurityStamp= Guid.NewGuid().ToString(),
                ImageId= Guid.Parse("1465691C-3690-40B6-9FAB-99A388205514")



            };

            superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "superadmin123");

            var admin = new AppUser
            {
                Id = Guid.Parse("0A3ADEE6-2F0D-42B7-83D3-22F95F64CCAB"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "1234567890",
                Firstname = "Demo",
                LastName = "Admin",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId= Guid.Parse("E37A4A99-7458-4089-A6DE-D5DBF52C95CD")

            };
            admin.PasswordHash = CreatePasswordHash(admin, "admin123");

            builder.HasData(superAdmin, admin);

        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordBuilder = new PasswordHasher<AppUser>();
            return passwordBuilder.HashPassword(user, password);
        }
    }
}
