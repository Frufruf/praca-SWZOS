using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    internal class ReservationPayments
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public string PriceListId { get; set; }

    }
}
