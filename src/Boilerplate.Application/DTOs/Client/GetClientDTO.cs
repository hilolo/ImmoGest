using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.DTOs.Client
{
    public class GetClientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public TypeClient TypeClient { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public Civility? Civility { get; set; }
        public string ICE { get; set; }
        public string RC { get; set; }
        public string Adresse { get; set; }
        public Guid OfficeId { get; set; }
    }
}




