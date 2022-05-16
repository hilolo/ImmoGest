using Boilerplate.Domain.Core.Entities;
using Boilerplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Domain.Entities
{
    public class Client : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
  
        [Required]
        public TypeClient TypeClient { get; set; }
        [Required]
        public TypeTransaction TypeTransaction { get; set; }
        public Civility? Civility { get; set; }
        public string ICE { get; set; }
        public string RC { get; set; }
        public string Adresse { get; set; }

    }
}
