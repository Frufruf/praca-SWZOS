using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class Equipment
    {
        //PK
        public int Id { get; set; }
        //Nazwa sprzętu
        public string Name { get; set; }
        //Ilość sprzętu w magazynie
        public int Quantity { get; set; }
        //Opis sprzętu
        public string Description { get; set; }
        public double Price { get; set; }
        public List<ReservationEquipment> ReservationsEquipment { get; set; }

    }
}
