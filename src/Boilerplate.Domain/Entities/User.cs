using System;
using System.ComponentModel.DataAnnotations;
using ImmoGest.Domain.Core.Entities;

namespace ImmoGest.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }                 
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }

        public override void BuildSearchTerms()
           => SearchTerms = $"D".ToLower();


    }
}

