using Microsoft.EntityFrameworkCore;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static SWZOS_Database.Enum;

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
                new PitchType { PitchTypeId = 1, PitchTypeName = "Boisko piłkarskie", PitchTypePrice = 120.00 },
                new PitchType { PitchTypeId = 2, PitchTypeName = "Boisko do koszykówki", PitchTypePrice = 80.00 },
                new PitchType { PitchTypeId = 3, PitchTypeName = "Boisko do siatkówki", PitchTypePrice = 80.00 },
                new PitchType { PitchTypeId = 4, PitchTypeName = "Kort tenisowy", PitchTypePrice = 50.00 }
            );

            modelBuilder.Entity<Pitch>().HasData(
                new Pitch { PitchId = 1, PitchTypeId = (int)PitchTypesEnum.Football, ActiveFlag = true, Desription = "Boisko do piłki nożnej" },
                new Pitch { PitchId = 2, PitchTypeId = (int)PitchTypesEnum.Football, ActiveFlag = true, Desription = "Boisko do piłki nożnej" },
                new Pitch { PitchId = 3, PitchTypeId = (int)PitchTypesEnum.Basketball, ActiveFlag = true, Desription = "Boisko do koszykówki" },
                new Pitch { PitchId = 4, PitchTypeId = (int)PitchTypesEnum.Basketball, ActiveFlag = true, Desription = "Boisko do koszykówki" },
                new Pitch { PitchId = 5, PitchTypeId = (int)PitchTypesEnum.Basketball, ActiveFlag = true, Desription = "Boisko do koszykówki" },
                new Pitch { PitchId = 6, PitchTypeId = (int)PitchTypesEnum.Volleyball, ActiveFlag = true, Desription = "Boisko do siatkówki" },
                new Pitch { PitchId = 7, PitchTypeId = (int)PitchTypesEnum.Volleyball, ActiveFlag = true, Desription = "Boisko do siatkówki" },
                new Pitch { PitchId = 8, PitchTypeId = (int)PitchTypesEnum.Volleyball, ActiveFlag = true, Desription = "Boisko do siatkówki" },
                new Pitch { PitchId = 9, PitchTypeId = (int)PitchTypesEnum.Tennis, ActiveFlag = true, Desription = "Kort tenisowy" },
                new Pitch { PitchId = 10, PitchTypeId = (int)PitchTypesEnum.Tennis, ActiveFlag = true, Desription = "Kort tenisowy" },
                new Pitch { PitchId = 11, PitchTypeId = (int)PitchTypesEnum.Tennis, ActiveFlag = true, Desription = "Kort tenisowy" },
                new Pitch { PitchId = 12, PitchTypeId = (int)PitchTypesEnum.Tennis, ActiveFlag = true, Desription = "Kort tenisowy" },
                new Pitch { PitchId = 13, PitchTypeId = (int)PitchTypesEnum.Tennis, ActiveFlag = true, Desription = "Kort tenisowy" },
                new Pitch { PitchId = 14, PitchTypeId = (int)PitchTypesEnum.Tennis, ActiveFlag = true, Desription = "Kort tenisowy" }
            );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "Piłka do piłki nożnej", Quantity = 20, Price = 3.00, Description = "Piłka do piłki nożnej o rozmiarze 5", MaximumQuantityPerReservation = 9 },
                new Equipment { Id = 2, Name = "Piłka do koszykówki", Quantity = 35, Price = 3.00, Description = "Piłka do koszykówki", MaximumQuantityPerReservation = 10 },
                new Equipment { Id = 3, Name = "Piłka do siatkówki", Quantity = 35, Price = 1.50, Description = "Piłka do siatkówki", MaximumQuantityPerReservation = 10 },
                new Equipment { Id = 4, Name = "Piłka do tenisa", Quantity = 200, Price = 0.00, Description = "Piłka do tenisa", MaximumQuantityPerReservation = 30 },
                new Equipment { Id = 5, Name = "Czerwone koszulki do gry", Quantity = 40, Price = 1.50, Description = "Koszulka sportowa", MaximumQuantityPerReservation = 18 },
                new Equipment { Id = 6, Name = "Niebieskie koszulki do gry", Quantity = 40, Price = 1.50, Description = "Koszulka sportowa", MaximumQuantityPerReservation = 18 },
                new Equipment { Id = 7, Name = "Białe koszulki do gry", Quantity = 40, Price = 1.50, Description = "Koszulka sportowa", MaximumQuantityPerReservation = 18 },
                new Equipment { Id = 8, Name = "Czarne koszulki do gry", Quantity = 40, Price = 1.50, Description = "Koszulka sportowa", MaximumQuantityPerReservation = 18 },
                new Equipment { Id = 9, Name = "Rakieta tenisowa", Quantity = 24, Price = 10.00, Description = "Rakieta do gry w tenisa", MaximumQuantityPerReservation = 4 }
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
