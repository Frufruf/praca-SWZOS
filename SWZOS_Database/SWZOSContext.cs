using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SWZOS_Database.Configuration.Seeds;

namespace SWZOS_Database
{
    public class SWZOSContext: DbContext
    {
        
        public SWZOSContext(DbContextOptions options): base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<ReservationEquipment> ReservationsEquipment { get; set; }
        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<PitchType> PitchTypes { get; set; }
        public DbSet<BlackList> BlackList { get; set; }
        public DbSet<BlackListStatus> BlackListStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWZOSContext).Assembly);
            modelBuilder.SeedData();
        }
    }
}
