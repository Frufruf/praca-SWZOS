using System;
using System.Collections.Generic;

namespace SWZOS.Models.Reservations
{
    public class ReservationsPageViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ReservationsViewModel> Reservations { get; set; }
    }
}
