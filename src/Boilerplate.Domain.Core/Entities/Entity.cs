using System;
using System.ComponentModel.DataAnnotations;

namespace ImmoGest.Domain.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public string SearchTerms { get; set; }
        public abstract void BuildSearchTerms();
    }
}
