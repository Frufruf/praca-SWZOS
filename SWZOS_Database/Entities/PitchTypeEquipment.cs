using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    //Tabela łącząca służąca do zapisywania dla jakiego boiska dostępne są które przedmioty
    //do wypożyczenia (np. Nie można wypożyczyć rakiety tenisowej na obiekt inny niż kort tenisowy)
    public class PitchTypeEquipment
    {
        public int PitchTypeId { get; set; }
        public int EquipmentId { get; set; }
        public PitchType PitchType { get; set; }
        public Equipment Equipment { get; set; }
    }
}
