using ImmoGest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Infrastructure.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
             builder.HasData(
                new Office
                {
                    Id = new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c6"),
                    Name = "ACCESIMMOTANGER"
                }
            );
        }
    }


}
