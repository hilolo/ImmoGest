using ImmoGest.Application.DTOs.Property;
using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.DTOs.Building
{
    public class CreateBuildingDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public TypeProperty TypeProperty { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OfficeId { get; set; }
        public ICollection<CreatePropertyDto> Propertys { get; set; }

    }
}
