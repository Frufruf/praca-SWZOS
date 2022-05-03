﻿using System;
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
        public List<Pitch> Pitches { get; set; }

    }
}