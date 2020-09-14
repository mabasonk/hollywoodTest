using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Resources
{
    public class EventResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int EventNumber { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public DateTime EventEndDate { get; set; }
        public bool AutoClose { get; set; }

        [Required]

        public long TournamentId { get; set; }
    }
}
