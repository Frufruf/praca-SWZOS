using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Entities
{
    public class PitchType
    {
        //PK
        public int PitchTypeId { get; set; }
        //Nazwa typu boiska
        public string PitchTypeName { get; set; }
        //Cena za godzinę wynajmu
        public double PitchTypePrice { get; set; }
        public List<Pitch> Pitches { get; set; }
        public List<PitchTypeEquipment> PitchTypeEquipment { get; set; }

    }
}
