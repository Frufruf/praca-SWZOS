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
    class ReservationsConfiguration: IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(e => e.ReservationId);

            builder.ToTable("RESERVATIONS");

            builder.Property(e => e.ReservationId)
                .HasColumnName("RESERVATION_ID")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(e => e.PitchId)
                .HasColumnName("PITCH_ID")
                .IsRequired();

            builder.Property(e => e.ReservationStartDate)
                .HasColumnName("START_DATE")
                .IsRequired();

            builder.Property(e => e.ReservationDuration)
                .HasColumnName("DURATION")
                .IsRequired();

            builder.Property(e => e.ReservationPrice)
                .HasColumnName("PRICE")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.ReservationStatus)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);

            builder.HasMany(e => e.Payments)
                .WithOne(p => p.Reservation)
                .HasForeignKey(p => p.ReservationId);
        }
    }
}
