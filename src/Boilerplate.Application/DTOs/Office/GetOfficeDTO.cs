using Boilerplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Application.DTOs.Office
{
    public class GetOfficeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string ICE { get; set; }
        public string RC { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }

    }
}
