using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZOS_Database.Configuration
{
    class GlobalConfiguration : IEntityTypeConfiguration<Global>
    {
        public void Configure(EntityTypeBuilder<Global> builder)
        {
            builder.HasKey(e => e.Key);

            builder.ToTable("GLOBAL");

            builder.Property(e => e.Key)
                .HasColumnName("KEY")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Value)
                .HasColumnName("VALUE");

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);
        }
    }
}
