using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    public class Pitch
    {
        //PK
        public int Id { get; set; }
        //Typ boiska
        public int PitchTypeId { get; set; }
        //Nazwa typu boiska
        public string Name { get; set; }
        //Cena za godzinę wynajmu
        public double Price { get; set; }
        //Flaga obsługująca wyłączenie boiska z użytku
        public bool ActiveFlag { get; set; }
        //Opis boiska
        public string Desription { get; set; }
    }
}
