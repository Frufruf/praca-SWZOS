using SWZOS.Models.Payments;
using System;
using System.Collections.Generic;

namespace SWZOS.Models.Reservations
{
    public class ReservationsViewModel
    {
        public int UserId { get; set; }
        public int ReservationId { get; set; }
        public int PitchId { get; set; }
        public int PitchTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public PaymentViewModel Payments { get; set; }

    }
}
