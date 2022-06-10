using ImmoGest.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.DTOs.Rental
{
    public class GetRentalDTO
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid PropertyId { get; set; }
        public Guid OfficeId { get; set; }
        public double Rent { get; set; }
        public int DayReceipe { get; set; }
        public TypeReceipt TypeReceipt { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
