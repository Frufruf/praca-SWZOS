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
    class PitchTypesConfiguration: IEntityTypeConfiguration<PitchType>
    {
        public void Configure(EntityTypeBuilder<PitchType> builder)
        {
            builder.HasKey(e => e.PitchTypeId);

            builder.ToTable("PITCH_TYPES");

            builder.Property(e => e.PitchTypeId)
                .HasColumnName("PITCH_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.PitchTypeName)
                .HasColumnName("PITCH_TYPE_NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PitchTypePrice)
                .HasColumnName("PITCH_TYPE_PRICE")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.HasMany(e => e.Pitches)
                .WithOne(p => p.PitchType)
                .HasForeignKey(p => p.PitchTypeId);
        }
    }
}
