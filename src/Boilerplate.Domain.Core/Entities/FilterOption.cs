using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Domain.Core.Entities
{
    public abstract class FilterOption
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SearchQuery { get; set; }
    }
}


