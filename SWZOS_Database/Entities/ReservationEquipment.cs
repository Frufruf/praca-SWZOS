using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class ReservationEquipment
    {
        //PK
        public int Id { get; set; }
        //Klucz obcy tabeli rezerwacji
        public int ReservationId { get; set; }
        //klucz obcy tabeli ze sprzętem
        public int EquipmentId  { get; set; }
        //Ilość sztuk wypożyczonego sprzętu
        public int Quantity { get; set; }   
        public Reservation Reservation { get; set; }
        public Equipment Equipment { get; set; }
    }
}
