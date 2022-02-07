using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class Reservation
    {
        //PK
        public int ReservationId { get; set; }
        //Klucz obcy użytkownika składającego rezerwację
        public int UserId { get; set; }
        //Klucz obcy boiska na którym założona została rezerwacja
        public int PitchId { get; set; }
        //Data rozpoczęcia rezerwacji
        public DateTime ReservationStartDate { get; set; }
        //Czas rezerwacji w minutach
        public int ReservationDuration { get; set; }
        //Pełna kwota rezerwacji
        public double ReservationPrice { get; set; }
        //Status rezerwacji
        public int ReservationStatus { get; set; }
        //Opis (dodatkowe informacje)
        public string Description { get; set; }
        public User User { get; set; }
        public Pitch Pitch { get; set; }
        public Payment Payment { get; set; }
        public List<ReservationEquipment> ReservationsEquipment { get; set; }
    }
}
