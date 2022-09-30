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
    class PaymentsStatusConfiguration: IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasKey(e => e.PaymentStatusId);

            builder.ToTable("PAYMENTS_STATUS");

            builder.Property(e => e.PaymentStatusId)
                .HasColumnName("PAYMENT_STATUS_ID")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(e => e.Payments)
                .WithOne(p => p.PaymentStatus)
                .HasForeignKey(p => p.StatusId);
        }
    }
}
