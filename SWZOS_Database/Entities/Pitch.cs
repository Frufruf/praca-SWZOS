using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class Pitch
    {
        //PK
        public int PitchId { get; set; }
        //Typ boiska
        public int PitchTypeId { get; set; }
        //Flaga obsługująca wyłączenie boiska z użytku
        public bool ActiveFlag { get; set; }
        //Opis boiska
        public string Desription { get; set; }
        public PitchType PitchType { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
