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
                new PitchType { PitchTypeId = 1, PitchTypeName = "Football pitch" },
                new PitchType { PitchTypeId = 2, PitchTypeName = "Basketball pitch"},
                new PitchType { PitchTypeId = 3, PitchTypeName = "Volleyball pitch" },
                new PitchType { PitchTypeId = 4, PitchTypeName = "Tennis court" }
            );

            modelBuilder.Entity<BlackListStatus>().HasData(
                new BlackListStatus { Id = 1, Name = "Waiting for approval" },
                new BlackListStatus { Id = 2, Name = "Approved" },
                new BlackListStatus { Id = 3, Name = "Rejected" },
                new BlackListStatus { Id = 4, Name = "Deleted" }
            );
        }
    }
}
