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
    public class Rental : Entity
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public double Rent { get; set; }
        public int DayReceipe { get; set; }
        public TypeReceipt TypeReceipt { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }   
        public override void BuildSearchTerms()
        => SearchTerms = $"".ToLower();
    }

}
