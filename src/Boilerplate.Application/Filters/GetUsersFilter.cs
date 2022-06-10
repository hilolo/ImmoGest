using ImmoGest.Domain.Core.Entities;
using System;

namespace ImmoGest.Application.Filters
{
    public class GetUsersFilter : FilterOption
    {
        public string Email { get; set; }
        public Guid OfficeId { get; set; }
    }
}
