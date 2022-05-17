using System;
using ImmoGest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BC = BCrypt.Net.BCrypt;

namespace ImmoGest.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(254);
            builder.HasIndex(x => x.Email).IsUnique();
            


            builder.HasData(
                new User
                {
                    Id = new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c1"),
                    Email = "admin@admin.com",
                    Role = "Admin",
                    Password = BC.HashPassword("admin"),
                    OfficeId = new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c6")
                },
                new User
                {
                    Id = new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c2"),
                    Email = "user@boilerplate.com",
                    Role = "User",
                    Password = BC.HashPassword("admin"),
                    OfficeId = new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c6")
                }
            );
        }
    }
}
