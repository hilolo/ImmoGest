using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.DTOs.Building
{
    public class GetBuildingDTO
    {
        public Guid Id { get; set; }
        public TypeProperty TypeProperty { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OfficeId { get; set; }
    }
}
