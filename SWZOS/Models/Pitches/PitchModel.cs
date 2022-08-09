using System;

namespace SWZOS.Models.Pitches
{
    public class PitchModel
    {
        public int PitchId { get; set; }
        public int PitchTypeId { get; set; }
        public string PitchTypeName { get; set; }
        public bool ActiveFlag { get; set; }
        public string Description { get; set; }
        public DateTime? OutOfServiceStartDate { get; set; }
        public DateTime? OutOfServiceEndDate { get; set; }
        public string OutOfServiceReason { get; set; }
    }
}
