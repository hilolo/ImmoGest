using ImmoGest.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Domain.Entities
{
    public class Building : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }
        public Guid OwnerId { get; set; }
        public Client Owner { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public override void BuildSearchTerms()
        => SearchTerms = $"".ToLower();
    }
}
