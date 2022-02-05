using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public double Fee { get; set; }
        public bool IsSettled { get; set; }
        public string Description { get; set; }
        public Reservation Reservation { get; set; }
    }
}
