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
    class ReservationsEquipmentConfiguration: IEntityTypeConfiguration<ReservationEquipment>
    {
        public void Configure(EntityTypeBuilder<ReservationEquipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("RESERVATIONS_EQUIPMENT");

            builder.Property(e => e.Id)
                .HasColumnName("RESERVATION_EQUIPMENT_ID")
                .IsRequired();

            builder.Property(e => e.ReservationId)
                .HasColumnName("RESERVATION_ID")
                .IsRequired();

            builder.Property(e => e.EquipmentId)
                .HasColumnName("EQUIPMENT_ID")
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("QUANTITY")
                .IsRequired();

            builder.HasOne(e => e.Reservation)
                .WithMany(u => u.ReservationsEquipment)
                .HasForeignKey(e => e.ReservationId);

            builder.HasOne(e => e.Equipment)
                .WithMany(u => u.ReservationsEquipment)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
