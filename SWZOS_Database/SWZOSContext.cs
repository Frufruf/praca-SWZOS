using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SWZOS_Database
{
    public class SWZOSContext: DbContext
    {
        public SWZOSContext(DbContextOptions options): base(options)
        {

        }

        //public DbSet<Pitch> Pitches { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }
        //public DbSet<IdentityUser> USERS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWZOSContext).Assembly);
        }
    }
}
