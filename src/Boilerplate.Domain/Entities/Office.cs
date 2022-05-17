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
 
    public class Office : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string ICE { get; set; }
        public string RC { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }
        public override void BuildSearchTerms()
          => SearchTerms = $"D".ToLower();

    }
}
