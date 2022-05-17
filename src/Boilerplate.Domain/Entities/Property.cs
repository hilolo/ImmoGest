using ImmoGest.Domain.Core.Entities;
using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Domain.Entities
{
    public class Property : Entity
    {

        [Required]
        public string identifier { get; set; }
        [Required]
        public TypeProperty TypeProperty { get; set; }
        public TypeRental TypeRental { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }

        public Guid OwnerId { get; set; }
        public Client Owner { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }

        public Guid? BuildingId { get; set; }
        public Building Building { get; set; }

        public override void BuildSearchTerms()
          => SearchTerms = $"D".ToLower();
    }
}
