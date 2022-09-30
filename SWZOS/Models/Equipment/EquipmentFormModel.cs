using System.Collections.Generic;

namespace SWZOS.Models.Equipment
{
    public class EquipmentFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MaximumQuantityPerReservation { get; set; }
        public List<int> PitchTypeIds { get; set; }
    }
}
