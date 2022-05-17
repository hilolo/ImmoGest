using ImmoGest.Domain.Core.Entities;
using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.Filters
{
    public class GetPropertyFilter : FilterOption
    {
        public string identifier { get; set; }
        public TypeProperty? TypeProperty { get; set; }
        public Guid OfficeId { get; set; }
        public Guid? BuildingId { get; set; }
        
    }
}
