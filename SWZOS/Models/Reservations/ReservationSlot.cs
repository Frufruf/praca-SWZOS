using System.Text.Json.Serialization;
using System;

namespace SWZOS.Models.Reservations
{
    public class ReservationSlot
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }

    }
}
