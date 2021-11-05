using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public int ReservationTime { get; set; }
        public string Description { get; set; }
    }
}
