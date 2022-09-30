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
            builder.HasKey(e => e.PitchId);

            builder.ToTable("PITCHES");

            builder.Property(e => e.PitchId)
                .HasColumnName("PITCH_ID")
                .IsRequired();

            builder.Property(e => e.PitchTypeId)
                .HasColumnName("PITCH_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.ActiveFlag)
                .HasColumnName("ACTIVE_FLAG")
                .IsRequired();

            builder.Property(e => e.Desription)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);

            builder.Property(e => e.OutOfServiceStartDate)
                .HasColumnName("OUT_OF_SERVICE_START_DATE");

            builder.Property(e => e.OutOfServiceEndDate)
                .HasColumnName("OUT_OF_SERVICE_END_DATE");

            builder.Property(e => e.OutOfServiceReason)
                .HasColumnName("OUT_OF_SERVICE_REASON")
                .HasMaxLength(4000);

            builder.HasMany(e => e.Reservations)
                .WithOne(r => r.Pitch)
                .HasForeignKey(r => r.PitchId);
        }
    }
}
