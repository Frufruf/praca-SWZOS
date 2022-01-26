using Microsoft.EntityFrameworkCore;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Configuration.Seeds
{
    public static partial class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
                new UserType { Id = 1, Name = "Admin" },
                new UserType { Id = 2, Name = "Employee"},
                new UserType { Id = 3, Name = "Customer"}
            );

            modelBuilder.Entity<PitchType>().HasData(
                new PitchType { Id = 1, PitchTypeName = "Football pitch" },
                new PitchType { Id = 2, PitchTypeName = "Basketball pitch"},
                new PitchType { Id = 3, PitchTypeName = "Volleyball pitch" },
                new PitchType { Id = 4, PitchTypeName = "Tennis court" }
            );
        }
    }
}
