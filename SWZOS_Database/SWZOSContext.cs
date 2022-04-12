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


        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWZOSContext).Assembly);
        }
    }
}
