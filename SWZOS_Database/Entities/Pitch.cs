using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Entities
{
    class Pitch
    {
        public int Id { get; set; }
        public int PitchTypeId { get; set; }
        public bool ActiveFlag { get; set; }
    }
}
