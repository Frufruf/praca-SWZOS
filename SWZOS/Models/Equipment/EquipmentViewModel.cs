using SWZOS.Models.Pitches;
using System.Collections.Generic;

namespace SWZOS.Models.Equipment
{
    public class EquipmentViewModel: EquipmentSimpleModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaximumAmountPerReservation { get; set; }
        public double Price { get; set; }
        public List<PitchTypeModel> PitchTypes { get; set; }
    }
}
