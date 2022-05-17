using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.DTOs.Client
{
    public class CreateClientDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        [Required(ErrorMessage = "Type Client is required")]
        public TypeClient TypeClient { get; set; }
        [Required(ErrorMessage = "Type Transaction  is required")]
        public TypeTransaction TypeTransaction { get; set; }
        public Civility? Civility { get; set; }
        public string ICE { get; set; }
        public string RC { get; set; }
        public string Adresse { get; set; }
        public Guid OfficeId { get; set; }
    }
}


