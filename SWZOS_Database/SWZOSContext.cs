using Microsoft.EntityFrameworkCore;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database
{
    public class SWZOSContext: DbContext
    {
        public SWZOSContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Pitch> Pitches { get; set; }
    }
}
