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
    class PaymentsConfiguration: IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(e => e.PaymentId);

            builder.ToTable("PAYMENTS");

            builder.Property(e => e.PaymentId)
                .HasColumnName("PAYMENT_ID")
                .IsRequired();

            builder.Property(e => e.ReservationId)
                .HasColumnName("RESERVATION_ID")
                .IsRequired();

            builder.Property(e => e.Fee)
                .HasColumnName("FEE")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.IsSettled)
                .HasColumnName("IS_SETTLED")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);
        }
    }
}
