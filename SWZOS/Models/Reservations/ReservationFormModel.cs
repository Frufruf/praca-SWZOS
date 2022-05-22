using System;

namespace SWZOS.Models.Reservations
{
    public class ReservationFormModel
    {
        public int UserId { get; set; }
        public int PitchTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
