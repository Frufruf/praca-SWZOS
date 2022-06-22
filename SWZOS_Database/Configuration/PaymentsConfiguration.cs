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

            builder.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(e => e.FullFee)
                .HasColumnName("FULL_FEE")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(e => e.AdvancePayment)
                .HasColumnName("ADVANCE_PAYMENT")
                .HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PaidInAmmount)
                .HasColumnName("PAID_IN_AMMOUNT")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(e => e.StatusId)
                .HasColumnName("PAYMENT_STATUS_ID")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(4000);

        }
    }
}
