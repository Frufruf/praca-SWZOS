using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class PriceList
    {
        //PK
        public int Id { get; set; }
        //Nazwa przedmiotu z cennika
        public string Name { get; set; }
        //Cena za godzinę wynajmu/wypożyczenia
        public double Price { get; set; }
        //Opis pozycji w cenniku
        public string Description { get; set; }


    }
}
