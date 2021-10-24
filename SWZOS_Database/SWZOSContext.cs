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

        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWZOSContext).Assembly);


        }
    }
}
