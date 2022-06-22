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
    public class PitchTypeEquipmentConfiguration: IEntityTypeConfiguration<PitchTypeEquipment>
    {
        public void Configure(EntityTypeBuilder<PitchTypeEquipment> builder)
        {
            builder.HasKey(e => new { e.PitchTypeId, e.EquipmentId });

            builder.ToTable("PITCH_TYPE_EQUIPMENT");

            builder.Property(e => e.PitchTypeId)
                .HasColumnName("PITCH_TYPE_ID")
                .IsRequired();

            builder.Property(e => e.EquipmentId)
                .HasColumnName("EQUIPMENT_ID")
                .IsRequired();

            builder.HasOne(e => e.PitchType)
                .WithMany(u => u.PitchTypeEquipment)
                .HasForeignKey(e => e.PitchTypeId);

            builder.HasOne(e => e.Equipment)
                .WithMany(u => u.PitchTypeEquipment)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
