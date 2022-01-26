using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database
{
    public class SWZOSContext: IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public SWZOSContext(DbContextOptions<SWZOSContext> options) : base(options)
        {

        }

        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<IdentityUser> USERS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWZOSContext).Assembly);
        }
    }
}
