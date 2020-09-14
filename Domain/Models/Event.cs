using System;

namespace HollywoodTest.Domain.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EventNumber { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public bool AutoClose { get; set; }


        public long TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
