using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodTest.Domain.Models
{
    public class EventDetail
    {
        public long EventDetailId { get; set; }
        public string EventDetailName { get; set; }
        public int EventDetailNumber { get; set; }
        public decimal EventDetailOdd { get; set; }
        public string FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }

        public long EventId { get; set; }
        public Event Event { get; set; }

        public EEventDetailStatus EventDetailStatus { get; set; }
    }
}
