using ImmoGest.Domain.Core.Entities;
using ImmoGest.Domain.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ImmoGest.Application.Filters
{
    public class GetClientesFilter : FilterOption
    {
        public string Name { get; set; }
        public TypeClient TypeClient { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public Guid OfficeId { get; set; }
    }
}
