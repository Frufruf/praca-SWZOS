using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWZOS_Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWZOS_Database.Configuration
{
    class PitchesConfiguraiton: IEntityTypeConfiguration<Pitch>
    {
        public void Configure(EntityTypeBuilder<Pitch> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("PITCHES");

            builder.Property(e => e.Id)
                .HasColumnName("PITCH_ID")
                .IsRequired();

            builder.Property(e => e.PitchTypeId)
                .HasColumnName("PITCH_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.ActiveFlag)
                .HasColumnName("ACTIVE_FLAG");
        }
    }
}
