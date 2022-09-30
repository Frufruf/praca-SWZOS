using SWZOS.Models.Equipment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWZOS.Models.Reservations
{
    public class ReservationFormModel
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int PitchTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool IsEditForm { get; set; }
        public double PitchPrice { get; set; }
        public List<EquipmentSimpleModel> EquipmentList { get; set; }
        public List<EquipmentSimpleModel> PitchEquipment { get; set; }
    }
}
