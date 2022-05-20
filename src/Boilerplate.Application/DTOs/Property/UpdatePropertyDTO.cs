using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.DTOs.Property
{
    public class UpdatePropertyDTO
    {
        public string Identifier { get; set; }
        public TypeProperty TypeProperty { get; set; }
        public TypeRental TypeRental { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OfficeId { get; set; }
        public Guid? BuildingId { get; set; }
    }
}
