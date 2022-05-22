using System;

namespace SWZOS.Models.Reservations
{
    public class ReservationsViewModel
    {
        public int UserId { get; set; }
        public int ReservationId { get; set; }
        public int PitchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

    }
}
