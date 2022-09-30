using SWZOS.Models.Pitches;
using System.Collections.Generic;

namespace SWZOS.Models.Equipment
{
    public class EquipmentViewModel: EquipmentSimpleModel
    {
        public string Description { get; set; }
        public List<PitchTypeModel> PitchTypes { get; set; }
    }
}
